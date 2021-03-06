﻿using FATCAAPI.Helpers;
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
        public VerifyFatcaFlagResponseModel VerifyFatcaFlag(VerifyFatcaFlagRequestModel requestModel)
        {
            Logging.WriteLog(requestModel);
            VerifyFatcaFlagResponseModel responseModel = new VerifyFatcaFlagResponseModel();
            responseModel.ReferenceNo = requestModel.ReferenceNo;
            try
            {
                string _sql = $"SELECT {nameof(DPI2195F1.F1CIFNO)}, TRIM({nameof(DPI2195F1.F1STS)}) AS {nameof(DPI2195F1.F1STS)}, TRIM({nameof(DPI2195F1.F1COD)}) AS {nameof(DPI2195F1.F1COD)} " +
                        $"FROM {appSettingService.GetLibrary(nameof(DPI2195F1))}.{nameof(DPI2195F1)} " +
                        $"WHERE {nameof(DPI2195F1.F1ID)} = '{requestModel.CustomerId}' AND {nameof(DPI2195F1.F1CIFNO)} = '{requestModel.CustomerNumber}'";

                if (AS400Singleton.Instance.ExecuteSql(_sql, out DataTable oDt, out string oMessage))
                {
                    if (oDt.Rows.Count > 0)
                    {
                        foreach (DataRow row in oDt.Rows)
                        {
                            responseModel.CustomerNumber = row[nameof(DPI2195F1.F1CIFNO)].ToString();
                            responseModel.FatcaFlag = row[nameof(DPI2195F1.F1STS)].ToString();
                            responseModel.FatcaCode = row[nameof(DPI2195F1.F1COD)].ToString();
                            break;
                        }
                    }
                    else
                    {
                        throw new NotFoundException($"{requestModel.CustomerNumber}");
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
        public CreateFatcaFlagResponseModel CreateFatcaFlag(CreateFatcaFlagRequestModel requestModel)
        {
            Logging.WriteLog(requestModel);
            CreateFatcaFlagResponseModel responseModel = new CreateFatcaFlagResponseModel();
            responseModel.ReferenceNo = requestModel.ReferenceNo;
            string jobName, outFile, ref_key;
            try
            {
                jobName = $"{appSettingService.GetLibJob(nameof(DPI21953))}/{nameof(DPI21953)}";
                outFile = $"{appSettingService.GetLibrary(nameof(DPI2195F4))}.{nameof(DPI2195F4)}";
                ref_key = $"{requestModel.BranchNumber.PadLeft(5, '0')}{requestModel.ReferenceNo.Substring(6,requestModel.ReferenceNo.Length - 6)}";
                List<string> param = new List<string>
                {
                    ref_key.PadRight(30, ' '),
                    requestModel.CustomerId.PadRight(15, ' '),
                    requestModel.CustomerNumber.PadLeft(19, '0'),
                    requestModel.Individual.PadRight(1, ' '),
                    requestModel.FatcaCode.PadRight(10, ' '),
                    requestModel.Corporation.PadRight(4, ' '),
                    requestModel.SSNITIN.PadRight(15, ' '),
                    requestModel.GIIN.PadRight(19, ' '),
                    $"{DateTime.Now.Day.ToString().PadLeft(2, '0')}{DateTime.Now.Month.ToString().PadLeft(2, '0')}{DateTime.Now.Year.ToString().PadLeft(2, '0')}",
                    requestModel.BranchNumber.PadLeft(3, '0'),
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
                                    responseModel.ReferenceKey = row[nameof(DPI2195F4.F4REFKEY)].ToString().Trim();
                                }
                                else
                                {
                                    responseModel.ReferenceKey = row[nameof(DPI2195F4.F4REFKEY)].ToString().Trim();
                                    responseModel.ErrorCode = row[nameof(DPI2195F4.F4STS)].ToString().Trim();
                                    responseModel.ErrorDescription = row[nameof(DPI2195F4.F4STDESC)].ToString().Trim();
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    responseModel.ErrorCode = ResponseCode.AS40000;
                    responseModel.ErrorDescription = oMessage;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ResponseCode.EXC0001;
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