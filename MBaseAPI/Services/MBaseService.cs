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

        public VerifyCitizenResponseModel VerifyCitizenID(VerifyCitizenRequestModel model, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = VerifyCitizenMessage(model, terminalId, processDateTime);

            // MBase Verify Citizen ID
            var mBaseResponse = MBaseSingleton.Instance.VerifyCitizenID(mBaseMessage);

            // Output Matching Object
            VerifyCitizenResponseModel responseModel = new VerifyCitizenResponseModel();
            PropertyMatcher<VerifyCitizenResponse, VerifyCitizenResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public CIFCreateResponseModel CIFCreation(CIFCreateRequestModel requestModel, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = CIFAccountCreationMessage(requestModel, terminalId, processDateTime);

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFCreation(mBaseMessage);

            // Output Matching Object
            CIFCreateResponseModel responseModel = new CIFCreateResponseModel();
            PropertyMatcher<CIFAccountResponse, CIFCreateResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public CIFAddressResponseModel CIFAddressCreate(CIFAddresRequestModel requestModel, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = CIFAddressCreateMessage(requestModel, terminalId, processDateTime);

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFAddressCreation(mBaseMessage);

            // Output Matching Object
            CIFAddressResponseModel responseModel = new CIFAddressResponseModel();
            PropertyMatcher<CIFAddressResponse, CIFAddressResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public KycCIFLevelResponseModel KycCIFLevelCreate(KycCIFLevelRequestModel requestModel, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = KycCIFLevelCreateMessage(requestModel, terminalId, processDateTime);

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.KycCIFLevelCreateMessage(mBaseMessage);

            // Output Matching Object
            KycCIFLevelResponseModel responseModel = new KycCIFLevelResponseModel();
            PropertyMatcher<KycCIFLevelResponse, KycCIFLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public KycAccountLevelResponseModel KycAccountLevelCreate(KycAccountLevelRequestModel requestModel, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = KycAccountLevelCreateMessage(requestModel, terminalId, processDateTime);

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.KycAccountLevelCreateMessage(mBaseMessage);

            // Output Matching Object
            KycAccountLevelResponseModel responseModel = new KycAccountLevelResponseModel();
            PropertyMatcher<KycAccountLevelResponse, KycAccountLevelResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }

        private MBaseMessage VerifyCitizenMessage(VerifyCitizenRequestModel model, string terminalId, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, model.BranchNumber, model.ReferenceNo, terminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(VerifyCitizen.CFSSNO):
                        s.DefaultValue = model.IDNumber;
                        break;
                    case nameof(VerifyCitizen.CFSSCD):
                        s.DefaultValue = model.IDTypeCode;
                        break;
                    case nameof(VerifyCitizen.CFCIDT):
                        s.DefaultValue = model.IDIssueCountryCode;
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage CIFAccountCreationMessage(CIFCreateRequestModel model, string terminalId, DateTime processDateTime)
        {
            // Header
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, model.BranchNumber, model.ReferenceNo, terminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            // Input
            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(CIFAccount.TCFTTIT):
                        s.DefaultValue = model.TitleThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1):
                        s.DefaultValue = model.ThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1A):
                        s.DefaultValue = model.ThaiSurename;
                        break;
                    case nameof(CIFAccount.TCFETIT):
                        s.DefaultValue = model.TitleEngName;
                        break;
                    case nameof(CIFAccount.TCFASN1):
                        s.DefaultValue = model.EngName;
                        break;
                    case nameof(CIFAccount.TCFASN2):
                        s.DefaultValue = model.EngSurename;
                        break;
                    case nameof(CIFAccount.CFSSNO):
                        s.DefaultValue = model.IDNumber;
                        break;
                    case nameof(CIFAccount.CFSSCD):
                        s.DefaultValue = model.IDTypeCode;
                        break;
                    case nameof(CIFAccount.CFCIDT):
                        s.DefaultValue = model.IDIssueCountryCode;
                        break;
                    case nameof(CIFAccount.BTCTYP):
                        s.DefaultValue = model.CustomerType;
                        break;
                    case nameof(CIFAccount.BTMBTY):
                        s.DefaultValue = model.MajorBusinessType;
                        break;
                    case nameof(CIFAccount.CFBRNN):
                        s.DefaultValue = model.BranchNumber;
                        break;
                    case nameof(CIFAccount.CFCOST):
                        s.DefaultValue = model.CostCenter;
                        break;
                    case nameof(CIFAccount.CFOFFR):
                        s.DefaultValue = model.OfficerCode;
                        break;
                    case nameof(CIFAccount.CFBIR8):
                        s.DefaultValue = model.BirthDate;
                        break;
                    case nameof(CIFAccount.CFRESD):
                        s.DefaultValue = model.ResidentCode;
                        break;
                    case nameof(CIFAccount.CFCNTY):
                        s.DefaultValue = model.Country;
                        break;
                    case nameof(CIFAccount.CFCITZ):
                        s.DefaultValue = model.CountryOfCitizenship;
                        break;
                    case nameof(CIFAccount.CFRACE):
                        s.DefaultValue = model.CountryOfHeritage;
                        break;
                    case nameof(CIFAccount.CFINQC):
                        s.DefaultValue = model.InquiryCode;
                        break;
                    case nameof(CIFAccount.CFEMPL):
                        s.DefaultValue = model.EmployerName;
                        break;
                    case nameof(CIFAccount.CFHPHO):
                        s.DefaultValue = model.HomePhone;
                        break;
                    case nameof(CIFAccount.CFBPHO):
                        s.DefaultValue = model.OfficePhone;
                        break;
                    case nameof(CIFAccount.CFBFHO):
                        s.DefaultValue = model.OtherPhone;
                        break;
                    case nameof(CIFAccount.CFSEX):
                        s.DefaultValue = model.Gender;
                        break;
                    case nameof(CIFAccount.CFSMSA):
                        s.DefaultValue = model.SMSACode;
                        break;
                    case nameof(CIFAccount.CFBUST):
                        s.DefaultValue = model.Occupation;
                        break;
                    case nameof(CIFAccount.CFSCLA):
                        s.DefaultValue = model.SubClass;
                        break;
                    case nameof(CIFAccount.CFCRAT):
                        s.DefaultValue = model.CustomerRating;
                        break;
                    case nameof(CIFAccount.CFGRUP):
                        s.DefaultValue = model.CIFGroupCode;
                        break;
                    case nameof(CIFAccount.CFCCYC):
                        s.DefaultValue = model.CIFCombinedCycle;
                        break;
                    case nameof(CIFAccount.CFTINS):
                        s.DefaultValue = model.TINStatus;
                        break;
                    case nameof(CIFAccount.CFWHCD):
                        s.DefaultValue = model.FedWHCode;
                        break;
                    case nameof(CIFAccount.CFWHPR):
                        s.DefaultValue = model.StateWHCode;
                        break;
                    case nameof(CIFAccount.CFINSC):
                        s.DefaultValue = model.InsiderCode;
                        break;
                    case nameof(CIFAccount.CFVIPC):
                        s.DefaultValue = model.VIPCustomer;
                        break;
                    case nameof(CIFAccount.CFDEAD):
                        s.DefaultValue = model.DeceasedCutomerFlag;
                        break;
                    case nameof(CIFAccount.CFBADA):
                        s.DefaultValue = model.InsufficientAddress;
                        break;
                    case nameof(CIFAccount.CFHLDM):
                        s.DefaultValue = model.HoldMailCode;
                        break;
                    case nameof(CIFAccount.CFFSD6):
                        s.DefaultValue = model.CustomerReviewDate;
                        break;
                    case nameof(CIFAccount.CFSIC1):
                        s.DefaultValue = model.SICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC2):
                        s.DefaultValue = model.SICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC3):
                        s.DefaultValue = model.SICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC4):
                        s.DefaultValue = model.SICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC5):
                        s.DefaultValue = model.SICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC6):
                        s.DefaultValue = model.SICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC7):
                        s.DefaultValue = model.SICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC8):
                        s.DefaultValue = model.SICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC1):
                        s.DefaultValue = model.UICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC2):
                        s.DefaultValue = model.UICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC3):
                        s.DefaultValue = model.UICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC4):
                        s.DefaultValue = model.UICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC5):
                        s.DefaultValue = model.UICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC6):
                        s.DefaultValue = model.UICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC7):
                        s.DefaultValue = model.UICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC8):
                        s.DefaultValue = model.UICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFLGID):
                        s.DefaultValue = model.LanguageIdentifier;
                        break;
                    case nameof(CIFAccount.CFRETN):
                        s.DefaultValue = model.Retention;
                        break;
                    case nameof(CIFAccount.SSCODE):
                        s.DefaultValue = model.DepositTypeCode;
                        break;
                    case nameof(CIFAccount.ACTYPE):
                        s.DefaultValue = model.AccountType;
                        break;
                    case nameof(CIFAccount.TLBSRC):
                        s.DefaultValue = model.SourceOfFunds;
                        break;
                    case nameof(CIFAccount.CRTAC):
                        s.DefaultValue = model.CreateAccountFlag;
                        break;
                    case nameof(CIFAccount.CFENA1):
                        s.DefaultValue = model.EmployerName01;
                        break;
                    case nameof(CIFAccount.CBINCC):
                        s.DefaultValue = model.IncomeCapitalAmount;
                        break;
                    case nameof(CIFAccount.CFZTYP):
                        s.DefaultValue = model.CompanyBusinessType;
                        break;
                    case nameof(CIFAccount.CFEDLV):
                        s.DefaultValue = model.EducationLevel;
                        break;
                    case nameof(CIFAccount.CFEADD):
                        s.DefaultValue = model.ElectronicAddress;
                        break;
                }
            });

            // Response
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage CIFAddressCreateMessage(CIFAddresRequestModel model, string terminalId, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, model.BranchNumber, model.ReferenceNo, terminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(CIFAddress.CFCIFN):
                        s.DefaultValue = model.CustomerNumber.Trim();
                        break;
                    case nameof(CIFAddress.CFNA2):
                        s.DefaultValue = model.AddressLine1.Trim();
                        break;
                    case nameof(CIFAddress.CFNA3):
                        s.DefaultValue = model.AddressLine2.Trim();
                        break;
                    case nameof(CIFAddress.CFNA4):
                        s.DefaultValue = model.AddressLine3.Trim();
                        break;
                    case nameof(CIFAddress.CFNA5):
                        s.DefaultValue = model.AddressLine4.Trim();
                        break;
                    case nameof(CIFAddress.CFNA6):
                        s.DefaultValue = model.AddressLine5.Trim();
                        break;
                    case nameof(CIFAddress.CFNA7):
                        s.DefaultValue = model.CityStateZip.Trim();
                        break;
                    case nameof(CIFAddress.CFSTAT):
                        s.DefaultValue = model.State.Trim();
                        break;
                    case nameof(CIFAddress.WKZIP):
                        s.DefaultValue = model.ZipCode.Trim();
                        break;
                    case nameof(CIFAddress.CFCOUN):
                        s.DefaultValue = model.Country.Trim();
                        break;
                    case nameof(CIFAddress.CFADRT):
                        s.DefaultValue = model.AddressType.Trim();
                        break;
                    case nameof(CIFAddress.CFARMK):
                        s.DefaultValue = model.AddressRemark.Trim();
                        break;
                    case nameof(CIFAddress.CFADFM):
                        s.DefaultValue = model.AddressFormat.Trim();
                        break;
                    case nameof(CIFAddress.CFFHNO):
                        s.DefaultValue = model.HouseNo.Trim();
                        break;
                    case nameof(CIFAddress.CFFVNO):
                        s.DefaultValue = model.VillageNo.Trim();
                        break;
                    case nameof(CIFAddress.CFFBLD):
                        s.DefaultValue = model.Building.Trim();
                        break;
                    case nameof(CIFAddress.CFFALY):
                        s.DefaultValue = model.Alley.Trim();
                        break;
                    case nameof(CIFAddress.CFFLAN):
                        s.DefaultValue = model.Lane.Trim();
                        break;
                    case nameof(CIFAddress.CFFRD):
                        s.DefaultValue = model.Road.Trim();
                        break;
                    case nameof(CIFAddress.CFFDIS):
                        s.DefaultValue = model.SubDistrict.Trim();
                        break;
                    case nameof(CIFAddress.CFFCIT):
                        s.DefaultValue = model.District.Trim();
                        break;
                    case nameof(CIFAddress.CFFST):
                        s.DefaultValue = model.Province.Trim();
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage KycCIFLevelCreateMessage(KycCIFLevelRequestModel model, string terminalId, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, model.BranchNumber, model.ReferenceNo, terminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(KycCIFLevel.KCCIFN):
                        s.DefaultValue = model.CustomerNumber.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOCPG):
                        s.DefaultValue = model.BusinessGroupCode.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCPRF):
                        s.DefaultValue = model.CustomerProofFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCIPRF):
                        s.DefaultValue = model.IdentificationProofFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCAPRF):
                        s.DefaultValue = model.ProofOfAddressDocumentFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCOUN):
                        s.DefaultValue = model.CustomerCountryCode.Trim();
                        break;
                    case nameof(KycCIFLevel.KCREPO):
                        s.DefaultValue = model.PoliticalRelationship.Trim();
                        break;
                    case nameof(KycCIFLevel.KCSCOU):
                        s.DefaultValue = model.CountrySourceOfFund.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOTHR):
                        s.DefaultValue = model.OtherInformation.Trim();
                        break;
                    case nameof(KycCIFLevel.KCASET):
                        s.DefaultValue = model.EstimationIncomeValue.Trim();
                        break;
                    case nameof(KycCIFLevel.KCCPLX):
                        s.DefaultValue = model.ComplexCompanyStructure.Trim();
                        break;
                    case nameof(KycCIFLevel.KCMTBA):
                        s.DefaultValue = model.TBAMembership.Trim();
                        break;
                    case nameof(KycCIFLevel.KCTAX):
                        s.DefaultValue = model.PayTax.Trim();
                        break;
                    case nameof(KycCIFLevel.KCRSET):
                        s.DefaultValue = model.SETRegistration.Trim();
                        break;
                    case nameof(KycCIFLevel.KCOFFS):
                        s.DefaultValue = model.OffshoreBusiness.Trim();
                        break;
                    case nameof(KycCIFLevel.KCICSH):
                        s.DefaultValue = model.CashIncome.Trim();
                        break;
                    case nameof(KycCIFLevel.KCSDOC):
                        s.DefaultValue = model.SufficientDocument.Trim();
                        break;
                    case nameof(KycCIFLevel.KCRTNF):
                        s.DefaultValue = model.ReturnMailFlag.Trim();
                        break;
                    case nameof(KycCIFLevel.KCNPO):
                        s.DefaultValue = model.NonProfitOrganization.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST1):
                        s.DefaultValue = model.XICSubType1.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD1):
                        s.DefaultValue = model.XICCode1.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK1):
                        s.DefaultValue = model.XICRemark1.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST2):
                        s.DefaultValue = model.XICSubType2.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD2):
                        s.DefaultValue = model.XICCode2.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK2):
                        s.DefaultValue = model.XICRemark2.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST3):
                        s.DefaultValue = model.XICSubType3.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD3):
                        s.DefaultValue = model.XICCode3.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK3):
                        s.DefaultValue = model.XICRemark3.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XST4):
                        s.DefaultValue = model.XICSubType4.Trim();
                        break;
                    case nameof(KycCIFLevel.CP9XCD4):
                        s.DefaultValue = model.XICCode4.Trim();
                        break;
                    case nameof(KycCIFLevel.CPXRMK4):
                        s.DefaultValue = model.XICRemark4.Trim();
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage KycAccountLevelCreateMessage(KycAccountLevelRequestModel model, string terminalId, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = InItializeHeader(headerTransaction, model.BranchNumber, model.ReferenceNo, terminalId, processDateTime);
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(KycAccountLevel.KCATYP):
                        s.DefaultValue = model.AccountType.Trim();
                        break;
                    case nameof(KycAccountLevel.KCACCN):
                        s.DefaultValue = model.AccountNumber.Trim();
                        break;
                    case nameof(KycAccountLevel.DEPPURINV):
                        s.DefaultValue = model.PurposeOfOpenAccount.Trim();
                        break;
                    case nameof(KycAccountLevel.DEPSRCINV):
                        s.DefaultValue = model.SourceOfFund.Trim();
                        break;
                    case nameof(KycAccountLevel.KCSCOU):
                        s.DefaultValue = model.SourceCountryOfFund.Trim();
                        break;
                    case nameof(KycAccountLevel.KCOPAM):
                        s.DefaultValue = model.OpenAmount.Trim();
                        break;
                }
            });
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }

        private HeaderMessageModel InItializeHeader(HeaderTransactionModel headerTransaction, string branchNumber, string referenceNo, string terminalId, DateTime processDateTime)
        {
            return new HeaderMessageModel
            {
                InputLength = headerTransaction.InputLength,
                I13SSNO = headerTransaction.ScenarioNumber,
                I13TRCD = headerTransaction.MBaseTranCode,
                HDBRNO = branchNumber,
                HDTXCD = headerTransaction.MBaseTranCode,
                HDACCD = headerTransaction.ActionMode,
                HDTMOD = headerTransaction.TransactionMode,
                HDNREC = headerTransaction.NoOfRecToRetrieve,
                I13TMID = terminalId,
                HDTMID = terminalId,
                HDRNUM = referenceNo,
                HDDTIN = processDateTime.ToString("ddMMyyyy"),
                HDTMIN = processDateTime.ToString("HHmmss")
            };
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
                    case nameof(MBaseHeaderMessage.SKTDEVN): // DB
                        item.DefaultValue = MBaseSingleton.Instance.ServerHost;
                        break;
                    case nameof(MBaseHeaderMessage.SKTSKNB): // DB
                        item.DefaultValue = "2";
                        break;
                    case nameof(MBaseHeaderMessage.SKTPORT): // DB
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