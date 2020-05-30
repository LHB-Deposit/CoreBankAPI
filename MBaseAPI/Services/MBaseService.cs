using MBaseAccess;
using MBaseAccess.Entity;
using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using Microsoft.Ajax.Utilities;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MBaseAPI.Services
{
    public class MBaseService : IMBaseService
    {
        private readonly ISQLService sQLService;
        private readonly IAs400Service as400Service;

        public MBaseService(ISQLService sQLService, IAs400Service as400Service)
        {
            this.sQLService = sQLService;
            this.as400Service = as400Service;
        }

        public VerifyCitizenResponseModel VerifyCitizenID(VerifyCitizenRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            VerifyCitizenResponseModel responseModel = new VerifyCitizenResponseModel();
            try
            {
                MBaseMessageModel mBaseMessageModel = VerifyCitizenMessage(requestModel, processDateTime);

                var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
                // MBase Verify Citizen ID
                var mBaseResponse = MBaseSingleton.Instance.VerifyCitizenID(mBaseMessage);

                // Output Matching Object
                
                PropertyMatcher<VerifyCitizenResponse, VerifyCitizenResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

                Logging.WriteLog(responseModel);
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message + ":" + ex.StackTrace);
            }
            return responseModel;
        }
        public CIFCreateResponseModel CIFCreation(CIFCreateRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            MBaseMessageModel mBaseMessageModel = CIFAccountCreationMessage(requestModel, processDateTime);

            var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFCreation(mBaseMessage);

            // Output Matching Object
            CIFCreateResponseModel responseModel = new CIFCreateResponseModel();
            PropertyMatcher<CIFAccountResponse, CIFCreateResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            Logging.WriteLog(responseModel);
            return responseModel;
        }
        public CIFAddressResponseModel CIFAddressCreate(CIFAddresRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            MBaseMessageModel mBaseMessageModel = CIFAddressCreateMessage(requestModel, processDateTime);

            var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFAddressCreation(mBaseMessage);

            // Output Matching Object
            CIFAddressResponseModel responseModel = new CIFAddressResponseModel();
            PropertyMatcher<CIFAddressResponse, CIFAddressResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            Logging.WriteLog(responseModel);
            return responseModel;
        }
        public KycCIFLevelResponseModel KycCIFLevelCreate(KycCIFLevelRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            MBaseMessageModel mBaseMessageModel = KycCIFLevelCreateMessage(requestModel, processDateTime);

            var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.KycCIFLevelCreateMessage(mBaseMessage);

            // Output Matching Object
            KycCIFLevelResponseModel responseModel = new KycCIFLevelResponseModel();
            PropertyMatcher<KycCIFLevelResponse, KycCIFLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            Logging.WriteLog(responseModel);
            return responseModel;
        }
        public KycAccountLevelResponseModel KycAccountLevelCreate(KycAccountLevelRequestModel requestModel, DateTime processDateTime)
        {
            Logging.WriteLog(requestModel);
            MBaseMessageModel mBaseMessageModel = KycAccountLevelCreateMessage(requestModel, processDateTime);

            var mBaseMessage = MBaseMessageMatchObject(mBaseMessageModel);
            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.KycAccountLevelCreateMessage(mBaseMessage);

            // Output Matching Object
            KycAccountLevelResponseModel responseModel = new KycAccountLevelResponseModel();
            PropertyMatcher<KycAccountLevelResponse, KycAccountLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);
            Logging.WriteLog(responseModel);
            return responseModel;
        }

        private MBaseMessageModel VerifyCitizenMessage(VerifyCitizenRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(requestModel.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(VerifyCitizen.CFSSNO):
                        s.DefaultValue = requestModel.IDNumber;
                        break;
                    case nameof(VerifyCitizen.CFSSCD):
                        s.DefaultValue = requestModel.IDTypeCode;
                        break;
                    case nameof(VerifyCitizen.CFCIDT):
                        s.DefaultValue = requestModel.IDIssueCountryCode;
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
        private MBaseMessageModel CIFAccountCreationMessage(CIFCreateRequestModel requestModel, DateTime processDateTime)
        {
            // Header
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            // Input
            var inputMessages = sQLService.GetInputMessages(requestModel.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(CIFAccount.TCFTTIT):
                        s.DefaultValue = requestModel.TitleThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1):
                        s.DefaultValue = requestModel.ThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1A):
                        s.DefaultValue = requestModel.ThaiSurename;
                        break;
                    case nameof(CIFAccount.TCFETIT):
                        s.DefaultValue = requestModel.TitleEngName;
                        break;
                    case nameof(CIFAccount.TCFASN1):
                        s.DefaultValue = requestModel.EngName;
                        break;
                    case nameof(CIFAccount.TCFASN2):
                        s.DefaultValue = requestModel.EngSurename;
                        break;
                    case nameof(CIFAccount.CFSSNO):
                        s.DefaultValue = requestModel.IDNumber;
                        break;
                    case nameof(CIFAccount.CFSSCD):
                        s.DefaultValue = requestModel.IDTypeCode;
                        break;
                    case nameof(CIFAccount.CFCIDT):
                        s.DefaultValue = requestModel.IDIssueCountryCode;
                        break;
                    case nameof(CIFAccount.BTCTYP):
                        s.DefaultValue = requestModel.CustomerType;
                        break;
                    case nameof(CIFAccount.BTMBTY):
                        s.DefaultValue = requestModel.MajorBusinessType;
                        break;
                    case nameof(CIFAccount.CFBRNN):
                        s.DefaultValue = requestModel.BranchNumber;
                        break;
                    case nameof(CIFAccount.CFCOST):
                        s.DefaultValue = requestModel.CostCenter;
                        break;
                    case nameof(CIFAccount.CFOFFR):
                        s.DefaultValue = requestModel.OfficerCode;
                        break;
                    case nameof(CIFAccount.CFBIR8):
                        s.DefaultValue = requestModel.BirthDate;
                        break;
                    case nameof(CIFAccount.CFRESD):
                        s.DefaultValue = requestModel.ResidentCode;
                        break;
                    case nameof(CIFAccount.CFCNTY):
                        s.DefaultValue = requestModel.Country;
                        break;
                    case nameof(CIFAccount.CFCITZ):
                        s.DefaultValue = requestModel.CountryOfCitizenship;
                        break;
                    case nameof(CIFAccount.CFRACE):
                        s.DefaultValue = requestModel.CountryOfHeritage;
                        break;
                    case nameof(CIFAccount.CFINQC):
                        s.DefaultValue = requestModel.InquiryCode;
                        break;
                    case nameof(CIFAccount.CFEMPL):
                        s.DefaultValue = requestModel.EmployerName;
                        break;
                    case nameof(CIFAccount.CFHPHO):
                        s.DefaultValue = requestModel.HomePhone;
                        break;
                    case nameof(CIFAccount.CFBPHO):
                        s.DefaultValue = requestModel.OfficePhone;
                        break;
                    case nameof(CIFAccount.CFBFHO):
                        s.DefaultValue = requestModel.OtherPhone;
                        break;
                    case nameof(CIFAccount.CFSEX):
                        s.DefaultValue = requestModel.Gender;
                        break;
                    case nameof(CIFAccount.CFSMSA):
                        s.DefaultValue = requestModel.SMSACode;
                        break;
                    case nameof(CIFAccount.CFBUST):
                        s.DefaultValue = requestModel.Occupation;
                        break;
                    case nameof(CIFAccount.CFSCLA):
                        s.DefaultValue = requestModel.SubClass;
                        break;
                    case nameof(CIFAccount.CFCRAT):
                        s.DefaultValue = requestModel.CustomerRating;
                        break;
                    case nameof(CIFAccount.CFGRUP):
                        s.DefaultValue = requestModel.CIFGroupCode;
                        break;
                    case nameof(CIFAccount.CFCCYC):
                        s.DefaultValue = requestModel.CIFCombinedCycle;
                        break;
                    case nameof(CIFAccount.CFTINS):
                        s.DefaultValue = requestModel.TINStatus;
                        break;
                    case nameof(CIFAccount.CFWHCD):
                        s.DefaultValue = requestModel.FedWHCode;
                        break;
                    case nameof(CIFAccount.CFWHPR):
                        s.DefaultValue = requestModel.StateWHCode;
                        break;
                    case nameof(CIFAccount.CFINSC):
                        s.DefaultValue = requestModel.InsiderCode;
                        break;
                    case nameof(CIFAccount.CFVIPC):
                        s.DefaultValue = requestModel.VIPCustomer;
                        break;
                    case nameof(CIFAccount.CFDEAD):
                        s.DefaultValue = requestModel.DeceasedCutomerFlag;
                        break;
                    case nameof(CIFAccount.CFBADA):
                        s.DefaultValue = requestModel.InsufficientAddress;
                        break;
                    case nameof(CIFAccount.CFHLDM):
                        s.DefaultValue = requestModel.HoldMailCode;
                        break;
                    case nameof(CIFAccount.CFFSD6):
                        s.DefaultValue = requestModel.CustomerReviewDate;
                        break;
                    case nameof(CIFAccount.CFSIC1):
                        s.DefaultValue = requestModel.SICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC2):
                        s.DefaultValue = requestModel.SICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC3):
                        s.DefaultValue = requestModel.SICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC4):
                        s.DefaultValue = requestModel.SICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC5):
                        s.DefaultValue = requestModel.SICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC6):
                        s.DefaultValue = requestModel.SICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC7):
                        s.DefaultValue = requestModel.SICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC8):
                        s.DefaultValue = requestModel.SICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC1):
                        s.DefaultValue = requestModel.UICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC2):
                        s.DefaultValue = requestModel.UICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC3):
                        s.DefaultValue = requestModel.UICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC4):
                        s.DefaultValue = requestModel.UICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC5):
                        s.DefaultValue = requestModel.UICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC6):
                        s.DefaultValue = requestModel.UICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC7):
                        s.DefaultValue = requestModel.UICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC8):
                        s.DefaultValue = requestModel.UICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFLGID):
                        s.DefaultValue = requestModel.LanguageIdentifier;
                        break;
                    case nameof(CIFAccount.CFRETN):
                        s.DefaultValue = requestModel.Retention;
                        break;
                    case nameof(CIFAccount.SSCODE):
                        s.DefaultValue = requestModel.DepositTypeCode;
                        break;
                    case nameof(CIFAccount.ACTYPE):
                        s.DefaultValue = requestModel.AccountType;
                        break;
                    case nameof(CIFAccount.TLBSRC):
                        s.DefaultValue = requestModel.SourceOfFunds;
                        break;
                    case nameof(CIFAccount.CRTAC):
                        s.DefaultValue = requestModel.CreateAccountFlag;
                        break;
                    case nameof(CIFAccount.CFENA1):
                        s.DefaultValue = requestModel.EmployerName01;
                        break;
                    case nameof(CIFAccount.CBINCC):
                        s.DefaultValue = requestModel.IncomeCapitalAmount;
                        break;
                    case nameof(CIFAccount.CFZTYP):
                        s.DefaultValue = requestModel.CompanyBusinessType;
                        break;
                    case nameof(CIFAccount.CFEDLV):
                        s.DefaultValue = requestModel.EducationLevel;
                        break;
                    case nameof(CIFAccount.CFEADD):
                        s.DefaultValue = requestModel.ElectronicAddress;
                        break;
                }
            });

            // Response
            var responseMessages = sQLService.GetResponseMessages(requestModel.TranCode);

            return new MBaseMessageModel
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessageModel CIFAddressCreateMessage(CIFAddresRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(requestModel.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(CIFAddress.CFCIFN):
                        s.DefaultValue = requestModel.CustomerNumber.Trim();
                        break;
                    case nameof(CIFAddress.CFNA2):
                        s.DefaultValue = requestModel.AddressLine1.Trim();
                        break;
                    case nameof(CIFAddress.CFNA3):
                        s.DefaultValue = requestModel.AddressLine2.Trim();
                        break;
                    case nameof(CIFAddress.CFNA4):
                        s.DefaultValue = requestModel.AddressLine3.Trim();
                        break;
                    case nameof(CIFAddress.CFNA5):
                        s.DefaultValue = requestModel.AddressLine4.Trim();
                        break;
                    case nameof(CIFAddress.CFNA6):
                        s.DefaultValue = requestModel.AddressLine5.Trim();
                        break;
                    case nameof(CIFAddress.CFNA7):
                        s.DefaultValue = requestModel.CityStateZip.Trim();
                        break;
                    case nameof(CIFAddress.CFSTAT):
                        s.DefaultValue = requestModel.State.Trim();
                        break;
                    case nameof(CIFAddress.WKZIP):
                        s.DefaultValue = requestModel.ZipCode.Trim();
                        break;
                    case nameof(CIFAddress.CFCOUN):
                        s.DefaultValue = requestModel.Country.Trim();
                        break;
                    case nameof(CIFAddress.CFADRT):
                        s.DefaultValue = requestModel.AddressType.Trim();
                        break;
                    case nameof(CIFAddress.CFARMK):
                        s.DefaultValue = requestModel.AddressRemark.Trim();
                        break;
                    case nameof(CIFAddress.CFADFM):
                        s.DefaultValue = requestModel.AddressFormat.Trim();
                        break;
                    case nameof(CIFAddress.CFFHNO):
                        s.DefaultValue = requestModel.HouseNo.Trim();
                        break;
                    case nameof(CIFAddress.CFFVNO):
                        s.DefaultValue = requestModel.VillageNo.Trim();
                        break;
                    case nameof(CIFAddress.CFFBLD):
                        s.DefaultValue = requestModel.Building.Trim();
                        break;
                    case nameof(CIFAddress.CFFALY):
                        s.DefaultValue = requestModel.Alley.Trim();
                        break;
                    case nameof(CIFAddress.CFFLAN):
                        s.DefaultValue = requestModel.Lane.Trim();
                        break;
                    case nameof(CIFAddress.CFFRD):
                        s.DefaultValue = requestModel.Road.Trim();
                        break;
                    case nameof(CIFAddress.CFFDIS):
                        s.DefaultValue = requestModel.SubDistrict.Trim();
                        break;
                    case nameof(CIFAddress.CFFCIT):
                        s.DefaultValue = requestModel.District.Trim();
                        break;
                    case nameof(CIFAddress.CFFST):
                        s.DefaultValue = requestModel.Province.Trim();
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
        private MBaseMessageModel KycCIFLevelCreateMessage(KycCIFLevelRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
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
        private MBaseMessageModel KycAccountLevelCreateMessage(KycAccountLevelRequestModel requestModel, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(requestModel.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, requestModel.BranchNumber, requestModel.ReferenceNo, requestModel.TerminalId, processDateTime);
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
        private HeaderMessageModel InItializeHeader(HeaderTransactionModel headerTransactionModel, string branchNumber, string referenceNo, string terminalId, DateTime processDateTime)
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
                HDRNUM = RandomReferenceNo(referenceNo.Substring(16, 7)),
                HDDTIN = processDateTime.ToString("ddMMyyyy"),
                HDTMIN = processDateTime.ToString("HHmmss")
            };
        }

        private string RandomReferenceNo(string strRef)
        {
            int maxValue = 9999999;
            int minValue = 0;
            Random random = new Random();
            if (!string.IsNullOrEmpty(strRef)) minValue = int.Parse(strRef);
            return random.Next(minValue, maxValue).ToString("D7");
        }
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

        public void GetConfigMessages(MBaseParameterModel parameterModel)
        {
            var mBaseMessageType = as400Service.GetMBaseMessages(parameterModel);
            foreach (var message in mBaseMessageType)
            {
                sQLService.AddMBaseMessage(message);
            }
            
        }

    }
}