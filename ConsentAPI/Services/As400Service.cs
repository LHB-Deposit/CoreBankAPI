using ConsentAPI.Interfaces;
using ConsentAPI.Models;
using iSeriesDataAccess;
using iSeriesDataAccess.FileModel;
using SolutionUtility;
using System;
using System.Data;

namespace ConsentAPI.Services
{
    public class As400Service : IAs400Service
    {
        private readonly IAppSettingService appSetting;

        public As400Service(IAppSettingService appSetting)
        {
            this.appSetting = appSetting;
        }
        public VerifyConsentResponseModel VerifyConsent(VerifyConsentRequestModel requestModel)
        {
            Logging.WriteLog(requestModel);
            VerifyConsentResponseModel responseModel = new VerifyConsentResponseModel();
            responseModel.ReferenceNo = requestModel.ReferenceNo;
            try
            {
                if (IsCifExists(requestModel.CustomerNumber, out string oMessage))
                {
                    string sql = $"SELECT TRIM({nameof(DPI2142F1.F1CIF)}) AS {nameof(DPI2142F1.F1CIF)}, TRIM({nameof(DPI2142F1.F1TYP)}) AS {nameof(DPI2142F1.F1TYP)}, " +
                            $"TRIM({nameof(DPI2142F1.F1COD)}) AS {nameof(DPI2142F1.F1COD)}, TRIM({nameof(DPI2142F1.F1STS)}) AS {nameof(DPI2142F1.F1STS)} " +
                            $"FROM {appSetting.GetLibrary(nameof(DPI2142F1))}.{nameof(DPI2142F1)} " +
                            $"WHERE {nameof(DPI2142F1.F1TYP)} = '001' AND {nameof(DPI2142F1.F1CIF)} = '{requestModel.CustomerNumber}' " +
                            $"ORDER BY {nameof(DPI2142F1.F1UPDT7)} DESC";
                    if (AS400Singleton.Instance.ExecuteSql(sql, out DataTable oDt, out oMessage))
                    {
                        if (oDt.Rows.Count > 0)
                        {
                            foreach (DataRow row in oDt.Rows)
                            {
                                responseModel.CustomerNumber = row[nameof(DPI2142F1.F1CIF)].ToString();
                                responseModel.DocumentType = row[nameof(DPI2142F1.F1TYP)].ToString();
                                responseModel.DocumentCode = row[nameof(DPI2142F1.F1COD)].ToString();
                                responseModel.ConsentFlag = row[nameof(DPI2142F1.F1STS)].ToString();
                            }
                        }
                        else
                        {
                            throw new NotFoundException($"Information on consent");
                        }
                    }
                    else
                    {
                        throw new Exception(oMessage);
                    }
                }
                else
                {
                    throw new Exception(oMessage);
                }
            }
            catch(NotFoundException ex)
            {
                responseModel.ErrorCode = ResponseCode.AS40000;
                responseModel.ErrorDescription = ex.Message;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ResponseCode.AS40001;
                responseModel.ErrorDescription = ex.Message;
            }
            finally
            {
                Logging.WriteLog(responseModel);
            }
            
            return responseModel;
        }

        public CreateConsentResponseModel CreateConsent(CreateConsentRequestModel requestModel)
        {
            Logging.WriteLog(requestModel);
            CreateConsentResponseModel responseModel = new CreateConsentResponseModel();
            responseModel.ReferenceNo = requestModel.ReferenceNo;
            DateTime processDateTime = DateTime.Now;
            try
            {
                string date6 = DateTimeUtils.ConvertToDate6(processDateTime);
                string date7 = DateTimeUtils.ConvertToJulian(processDateTime);
                if (IsCifExists(requestModel.CustomerNumber, out string oMessage))
                {
                    string sql = $"INSERT INTO {appSetting.GetLibrary(nameof(DPI2142F1))}.{nameof(DPI2142F1)} " +
                        $"({nameof(DPI2142F1.F1CIF)}, {nameof(DPI2142F1.F1TYP)}, {nameof(DPI2142F1.F1COD)}, " +
                        $"{nameof(DPI2142F1.F1STS)}, {nameof(DPI2142F1.F1REMRK)}, {nameof(DPI2142F1.F1CTBRN)}, " +
                        $"{nameof(DPI2142F1.F1CTDT6)}, {nameof(DPI2142F1.F1CTDT7)}, {nameof(DPI2142F1.F1UPBRN)}, " +
                        $"{nameof(DPI2142F1.F1UPDT6)}, {nameof(DPI2142F1.F1UPDT7)}, {nameof(DPI2142F1.F1UPUSR)}) " +
                        $"VALUES('{requestModel.CustomerNumber}', '{requestModel.DocumentType}', '{requestModel.DocumentCode}', " +
                        $"'{requestModel.ConsentFlag}', '{requestModel.Remark}', '{requestModel.BranchNumber}', " +
                        $"'{date6}', '{date7}', '{requestModel.BranchNumber}', " +
                        $"'{date6}', '{date7}', '{requestModel.User}')";
                    if (AS400Singleton.Instance.ExecuteSql(sql, out DataTable oDt, out oMessage))
                    {
                        responseModel.CustomerNumber = requestModel.CustomerNumber;
                        responseModel.DocumentType = requestModel.DocumentType;
                        responseModel.DocumentCode = requestModel.DocumentCode;
                        responseModel.ConsentFlag = requestModel.ConsentFlag;
                        responseModel.CreateDate = processDateTime.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        throw new Exception(oMessage);
                    }
                }
                else
                {
                    throw new NotFoundException(oMessage);
                }
            }
            catch(NotFoundException ex)
            {
                responseModel.ErrorCode = ResponseCode.AS40000;
                responseModel.ErrorDescription = ex.Message;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ResponseCode.EXC0001;
                responseModel.ErrorDescription = ex.Message;
            }
            finally
            {
                Logging.WriteLog(responseModel);
            }

            return responseModel;
        }

        private bool IsCifExists(string customerNumber, out string oMessage)
        {
            bool IsExists = false;
            oMessage = string.Empty;

            string sql = $"SELECT {nameof(CFMAST.CFCIFN)} " +
                $"FROM {appSetting.GetLibrary(nameof(CFMAST))}.{nameof(CFMAST)} " +
                $"WHERE {nameof(CFMAST.CFCIFN)} = '{customerNumber}'";
            if (AS400Singleton.Instance.ExecuteSql(sql, out DataTable oDt, out oMessage))
            {
                if (oDt.Rows.Count > 0) IsExists = true;
                else throw new NotFoundException($"{customerNumber}");
            }

            return IsExists;
        }
    }
}