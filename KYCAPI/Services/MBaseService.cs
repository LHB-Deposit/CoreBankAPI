using iSeriesDataAccess;
using iSeriesDataAccess.FileModel;
using KYCAPI.Helpers;
using KYCAPI.Interfaces;
using KYCAPI.Models;
using MBaseAccess;
using MBaseAccess.Entity;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KYCAPI.Services
{
    public class MBaseService : IMBaseService
    {
        private readonly ISQLService sQLService;

        public MBaseService(ISQLService sQLService)
        {
            this.sQLService = sQLService;
        }
        public KycCIFLevelResponseModel CreateKycCIFLevel(KycCIFLevelRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            KycCIFLevelResponseModel responseModel = new KycCIFLevelResponseModel();
            try
            {
                MBaseMessageModel mBaseMessageModel = CreateKycCIFLevelMessage(requestModel, processDateTime);

                var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
                // MBase CIFCreate
                var mBaseResponse = MBaseSingleton.Instance.CreateKycCIFLevelMessage(mBaseMessage);

                // Output Matching Object
                PropertyMatcher<KycCIFLevelResponse, KycCIFLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);
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
        public KycAccountLevelResponseModel CreateKycAccountLevel(KycAccountLevelRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            KycAccountLevelResponseModel responseModel = new KycAccountLevelResponseModel();
            try
            {
                MBaseMessageModel mBaseMessageModel = CreateKycAccountLevelMessage(requestModel, processDateTime);

                var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
                // MBase CIFCreate
                var mBaseResponse = MBaseSingleton.Instance.CreateKycAccountLevelMessage(mBaseMessage);

                // Output Matching Object
                PropertyMatcher<KycAccountLevelResponse, KycAccountLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);
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
        public KycRiskLevelResponseModel CheckKycRiskLevel(KycRiskLevelRequestModel requestModel, AppSettings appSettings)
        {
            Logging.WriteLog(requestModel);
            KycRiskLevelResponseModel responseModel = new KycRiskLevelResponseModel();
            string sql = $@"SELECT {nameof(KCMAST.KCCIFN)}, {nameof(KCMAST.KCRRKL)} 
                            FROM {appSettings.LIB}.{appSettings.FILE} 
                            WHERE {nameof(KCMAST.KCCIFN)} = '{requestModel.CustomerNumber}'";
            try
            {
                if(AS400Singleton.Instance.ExecuteSql(sql, out DataTable dt, out string oMessage))
                {
                    if(dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            responseModel.CustomerNumber = row[nameof(KCMAST.KCCIFN)].ToString();
                            responseModel.RiskLevel = row[nameof(KCMAST.KCRRKL)].ToString();
                        }
                    }
                    else
                    {
                        responseModel.ErrorCode = ResponseCode.INF0001;
                        responseModel.ErrorDescription = "Record not found";
                    }
                }
                else
                {
                    responseModel.ErrorCode = ResponseCode.SQL0001;
                    responseModel.ErrorDescription = oMessage;
                    Logging.WriteLog(oMessage);
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = ResponseCode.EXC0001;
                responseModel.ErrorDescription = ex.Message;
                Logging.WriteLog(ex.Message);
            }
            Logging.WriteLog(responseModel);
            return responseModel;
        }

        private MBaseMessageModel CreateKycCIFLevelMessage(KycCIFLevelRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InitializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(requestModel.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(KycCIFLevel.KCCIFN):
                        s.DefaultValue = requestModel.CustomerNumber.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOCPG):
                        s.DefaultValue = requestModel.BusinessGroupCode.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCPRF):
                        s.DefaultValue = requestModel.CustomerProofFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCIPRF):
                        s.DefaultValue = requestModel.IdentificationProofFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCAPRF):
                        s.DefaultValue = requestModel.ProofOfAddressDocumentFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCOUN):
                        s.DefaultValue = requestModel.CustomerCountryCode.Trim();
                        break;
                    case nameof(KycCIFLevel.KCREPO):
                        s.DefaultValue = requestModel.PoliticalRelationship.Trim();
                        break;
                    case nameof(KycCIFLevel.KCSCOU):
                        s.DefaultValue = requestModel.CountrySourceOfFund.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOTHR):
                        s.DefaultValue = requestModel.OtherInformation.Trim();
                        break;
                    case nameof(KycCIFLevel.KCASET):
                        s.DefaultValue = requestModel.EstimationIncomeValue.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCPLX):
                        s.DefaultValue = requestModel.ComplexCompanyStructure.Trim();
                        break;
                    case nameof(KycCIFLevel.KCMTBA):
                        s.DefaultValue = requestModel.TBAMembership.Trim();
                        break;
                    case nameof(KycCIFLevel.KCTAX):
                        s.DefaultValue = requestModel.PayTax.Trim();
                        break;
                    case nameof(KycCIFLevel.KCRSET):
                        s.DefaultValue = requestModel.SETRegistration.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOFFS):
                        s.DefaultValue = requestModel.OffshoreBusiness.Trim();
                        break;
                    case nameof(KycCIFLevel.KCICSH):
                        s.DefaultValue = requestModel.CashIncome.Trim();
                        break;
                    case nameof(KycCIFLevel.KCSDOC):
                        s.DefaultValue = requestModel.SufficientDocument.Trim();
                        break;
                    case nameof(KycCIFLevel.KCRTNF):
                        s.DefaultValue = requestModel.ReturnMailFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCNPO):
                        s.DefaultValue = requestModel.NonProfitOrganization.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST1):
                        s.DefaultValue = requestModel.XICSubType1.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD1):
                        s.DefaultValue = requestModel.XICCode1.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK1):
                        s.DefaultValue = requestModel.XICRemark1.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST2):
                        s.DefaultValue = requestModel.XICSubType2.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD2):
                        s.DefaultValue = requestModel.XICCode2.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK2):
                        s.DefaultValue = requestModel.XICRemark2.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST3):
                        s.DefaultValue = requestModel.XICSubType3.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD3):
                        s.DefaultValue = requestModel.XICCode3.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK3):
                        s.DefaultValue = requestModel.XICRemark3.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST4):
                        s.DefaultValue = requestModel.XICSubType4.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD4):
                        s.DefaultValue = requestModel.XICCode4.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK4):
                        s.DefaultValue = requestModel.XICRemark4.Trim();
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(requestModel.TranCode);

            return new MBaseMessageModel
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessageModel CreateKycAccountLevelMessage(KycAccountLevelRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InitializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(requestModel.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(KycAccountLevel.KCATYP):
                        s.DefaultValue = requestModel.AccountType.Trim();
                        break;
                    case nameof(KycAccountLevel.KCACCN):
                        s.DefaultValue = requestModel.AccountNumber.Trim();
                        break;
                    case nameof(KycAccountLevel.DEPPURINV):
                        s.DefaultValue = requestModel.PurposeOfOpenAccount.Trim();
                        break;
                    case nameof(KycAccountLevel.DEPSRCINV):
                        s.DefaultValue = requestModel.SourceOfFund.Trim();
                        break;
                    case nameof(KycAccountLevel.KCSCOU):
                        s.DefaultValue = requestModel.SourceCountryOfFund.Trim();
                        break;
                    case nameof(KycAccountLevel.KCOPAM):
                        s.DefaultValue = requestModel.OpenAmount.Trim();
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(requestModel.TranCode);

            return new MBaseMessageModel
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage MBaseMessageMatchObject(MBaseMessageModel messageModel)
        {
            // Header Transaction
            var headerTransaction = new MBaseHeaderTransaction();
            PropertyMatcher<HeaderTransactionModel, MBaseHeaderTransaction>.GenerateMatchedObject(messageModel.HeaderTransaction, headerTransaction);

            // Header Message
            var headerMessages = new List<MBaseMessageType>();
            foreach (var itmType in messageModel.HeaderMessages)
            {
                var mbaseMessageType = new MBaseMessageType();
                PropertyMatcher<MessageTypeModel, MBaseMessageType>.GenerateMatchedObject(itmType, mbaseMessageType);
                headerMessages.Add(mbaseMessageType);
            }

            // Input Message
            var inputMessages = new List<MBaseMessageType>();
            foreach (var itmType in messageModel.InputMessages)
            {
                var mbaseMessageType = new MBaseMessageType();
                PropertyMatcher<MessageTypeModel, MBaseMessageType>.GenerateMatchedObject(itmType, mbaseMessageType);
                inputMessages.Add(mbaseMessageType);
            }

            // Response Message
            var responseMessages = new List<MBaseMessageType>();
            foreach (var itmType in messageModel.ResponseMessages)
            {
                var mbaseMessageType = new MBaseMessageType();
                PropertyMatcher<MessageTypeModel, MBaseMessageType>.GenerateMatchedObject(itmType, mbaseMessageType);
                responseMessages.Add(mbaseMessageType);
            }
            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private HeaderMessageModel InitializeHeader(HeaderTransactionModel headerTransactionModel, string branchNumber, string referenceNo, string terminalId, DateTime processDateTime)
        {
            return new HeaderMessageModel
            {
                InputLength = headerTransactionModel.InputLength,
                I13SSNO = headerTransactionModel.ScenarioNumber,
                I13TRCD = headerTransactionModel.MBaseTranCode,
                HDBRNO = branchNumber,
                HDTXCD = headerTransactionModel.MBaseTranCode,
                HDACCD = headerTransactionModel.ActionMode,
                HDTMOD = headerTransactionModel.TransactionMode,
                HDNREC = headerTransactionModel.NoOfRecToRetrieve,
                I13TMID = terminalId,
                HDTMID = terminalId,
                HDRNUM = NumberUtils.RandomReferenceNo(referenceNo.Substring(16, 7)).ToString("D7"),
                HDDTIN = processDateTime.ToString("ddMMyyyy"),
                HDTMIN = processDateTime.ToString("HHmmss")
            };
        }

        // TodoFix UserAS400
        private IEnumerable<MessageTypeModel> GetHeaderMessage(HeaderMessageModel header)
        {
            IEnumerable<MessageTypeModel> headerMessages = sQLService.GetHeaderMessage();
            headerMessages.ToList().ForEach(item =>
            {
                // Todo Fix DefaultValue From DataBase
                switch (item.FieldName.Trim())
                {
                    case nameof(MBaseHeaderMessage.SKTMLEN):
                        item.DefaultValue = ((MBaseSingleton.Instance.HeaderMessageLength + header.InputLength) - 4).ToString();
                        break;
                    case nameof(MBaseHeaderMessage.SKTDEVN):
                        item.DefaultValue = MBaseSingleton.Instance.ServerHost;
                        break;
                    //case nameof(MBaseHeaderMessage.SKTSKNB): // DB
                    //    item.DefaultValue = he;
                    //    break;
                    case nameof(MBaseHeaderMessage.SKTPORT):
                        item.DefaultValue = MBaseSingleton.Instance.ServerPort.ToString();
                        break;
                    case nameof(MBaseHeaderMessage.I13SSNO):
                        item.DefaultValue = header.I13SSNO;
                        break;
                    case nameof(MBaseHeaderMessage.I13TRCD):
                        item.DefaultValue = header.I13TRCD;
                        break;
                    case nameof(MBaseHeaderMessage.I13USER): // DB
                        item.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeaderMessage.HDUSID): // DB
                        item.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeaderMessage.HDSRID): // DB
                        item.DefaultValue = "EFP";
                        break;
                    case nameof(MBaseHeaderMessage.HDBKNO): // DB
                        item.DefaultValue = "73";
                        break;
                    case nameof(MBaseHeaderMessage.HDBRNO):
                        item.DefaultValue = header.HDBRNO.PadLeft(5, '0');
                        break;
                    case nameof(MBaseHeaderMessage.HDTXCD):
                        item.DefaultValue = header.HDTXCD;
                        break;
                    case nameof(MBaseHeaderMessage.HDACCD):
                        item.DefaultValue = header.HDACCD;
                        break;
                    case nameof(MBaseHeaderMessage.HDTMOD):
                        item.DefaultValue = header.HDTMOD;
                        break;
                    case nameof(MBaseHeaderMessage.HDNREC):
                        item.DefaultValue = header.HDNREC;
                        break;
                    case nameof(MBaseHeaderMessage.I13TMID):
                        item.DefaultValue = header.I13TMID;
                        break;
                    case nameof(MBaseHeaderMessage.HDTMID):
                        item.DefaultValue = header.HDTMID;
                        break;
                    case nameof(MBaseHeaderMessage.HDRNUM):
                        item.DefaultValue = header.HDRNUM;
                        break;
                    case nameof(MBaseHeaderMessage.HDDTIN):
                        item.DefaultValue = header.HDDTIN;
                        break;
                    case nameof(MBaseHeaderMessage.HDTMIN):
                        item.DefaultValue = header.HDTMIN;
                        break;
                }
            });
            return headerMessages;
        }
    }
}