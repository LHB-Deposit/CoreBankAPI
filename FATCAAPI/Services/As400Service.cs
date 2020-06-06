using FATCAAPI.Helpers;
using FATCAAPI.Interfaces;
using FATCAAPI.Models;
using iSeriesDataAccess;
using iSeriesDataAccess.FileModel;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FATCAAPI.Services
{
    public class As400Service : IAs400Service
    {
        private readonly IAppSettingService appSettingService;

        public As400Service(IAppSettingService appSettingService)
        {
            this.appSettingService = appSettingService;
        }
        public FatcaFlagResponseModel VerifyFatcaFlag(FatcaFlagRequesstModel model)
        {
            FatcaFlagResponseModel responseModel = new FatcaFlagResponseModel();

            string _sql = $"SELECT {nameof(DPI2195F1.F1STS)}, {nameof(DPI2195F1.F1COD)} " +
                $"FROM {appSettingService.GetLibrary(nameof(DPI2195F1))}.{nameof(DPI2195F1)}" +
                $"WHERE {nameof(DPI2195F1.F1CIFNO)} = '{model.CustomerNumber}'";

            if(AS400Singleton.Instance.ExecuteSql(_sql, out DataTable oDt, out string oMessage))
            {
                foreach (DataRow row in oDt.Rows)
                {
                    responseModel.FatcaFlag = row[nameof(DPI2195F1.F1STS)].ToString().Trim();
                    responseModel.FatcaCode = row[nameof(DPI2195F1.F1COD)].ToString().Trim();
                    break;
                }
            }
            else
            {
                responseModel.ErrorCode = ErrorCode.AS40001;
                responseModel.ErrorDescription = oMessage;
            }

            return responseModel;
        }
        public FatcaFlagResponseModel CreateFatcaFlag(FatcaFlagRequesstModel requestModel)
        {
            Logging.WriteLog(requestModel);
            FatcaFlagResponseModel responseModel = new FatcaFlagResponseModel();
            string jobName, outFile, ref_key;
            try
            {
                jobName = $"{appSettingService.GetLibJob(nameof(DPI21953))}/{nameof(DPI21953)}";
                outFile = $"{appSettingService.GetLibrary(nameof(DPI2195F4))}.{nameof(DPI2195F4)}";
                ref_key = $"{requestModel.BranchNumber.PadLeft(5, '0')}{requestModel.ReferenceNo}";
                List<string> param = new List<string>
                {
                    ref_key.PadRight(30, ' '),
                    requestModel.CustomerId.PadRight(15, ' '),
                    requestModel.CustomerNumber.PadLeft(19, '0'),
                    requestModel.Individual.PadRight(1, ' '),
                    requestModel.FatcaCode.PadRight(10, ' '),
                    requestModel.Corporation.PadRight(4, ' '),
                    requestModel.Username.PadRight(10, ' ')
                };

                if(AS400Singleton.Instance.SubmitJob(jobName, string.Join("", param), out string oMessage))
                {
                    System.Threading.Thread.Sleep(2000);
                    string _sql = $"SELECT {nameof(DPI2195F4.F4REFKEY)}, {nameof(DPI2195F4.F4STS)}, {nameof(DPI2195F4.F4STDESC)} " +
                        $"FROM {outFile} " +
                        $"WHERE {nameof(DPI2195F4.F4REFKEY)} = '{ref_key}' AND {nameof(DPI2195F4.F4STS)} > '0'";
                    if (AS400Singleton.Instance.ExecuteSql(_sql, out DataTable dt, out oMessage))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row[nameof(DPI2195F4.F4STS)].ToString().Trim().Equals("1"))
                                {
                                    responseModel.ReferenceNo = row[nameof(DPI2195F4.F4REFKEY)].ToString().Trim();
                                    responseModel.FatcaFlag = row[nameof(DPI2195F4.F4STS)].ToString().Trim();
                                    responseModel.FatcaCode = row[nameof(DPI2195F4.F4STDESC)].ToString().Trim();
                                }
                                else
                                {
                                    responseModel.ErrorCode = ErrorCode.AS40001;
                                    responseModel.ErrorDescription = row[nameof(DPI2195F4.F4STDESC)].ToString();
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    responseModel.ErrorCode = ErrorCode.AS40001;
                    responseModel.ErrorDescription = oMessage;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ErrorCode.EXC0001;
                responseModel.ErrorDescription = ex.Message;
                Logging.WriteLog(ex.Message);
            }
            finally
            {
                Logging.WriteLog(responseModel);
            }
            return responseModel;
        }
    }
}