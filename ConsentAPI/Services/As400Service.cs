using ConsentAPI.Interfaces;
using ConsentAPI.Models;
using iSeriesDataAccess;
using iSeriesDataAccess.FileModel;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
                            responseModel.ErrorCode = ErrorCode.AS40003;
                            responseModel.ErrorDescription = $"Don't have the consent data.";
                        }
                    }
                    else
                    {
                        responseModel.ErrorCode = ErrorCode.AS40001;
                        responseModel.ErrorDescription = oMessage;
                    }
                }
                else
                {
                    responseModel.ErrorCode = ErrorCode.AS40000;
                    responseModel.ErrorCode = oMessage;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ErrorCode.EXC0001;
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
                        responseModel.ErrorCode = ErrorCode.AS40001;
                        responseModel.ErrorDescription = oMessage;
                    }
                }
                else
                {
                    responseModel.ErrorCode = ErrorCode.AS40000;
                    responseModel.ErrorDescription = oMessage;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ErrorCode.EXC0001;
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
                else oMessage = $"{customerNumber} not found.";
            }
            else
            {
                throw new Exception(oMessage);
            }

            return IsExists;
        }
    }
}