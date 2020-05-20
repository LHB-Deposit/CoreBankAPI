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

        public VerifyCitizenIDResponseModel VerifyCitizenID(VerifyCitizenIDModel model, string terminalId, DateTime processDateTime)
        {
            MBaseMessage mBaseMessage = VerifyCitizenMessage(model, terminalId, processDateTime);

            // MBase Verify Citizen ID
            var mBaseResponse = MBaseSingleton.Instance.VerifyCitizenID(mBaseMessage);

            // Output Matching Object
            VerifyCitizenIDResponseModel responseModel = new VerifyCitizenIDResponseModel();
            PropertyMatcher<VerifyCitizenIDResponse, VerifyCitizenIDResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

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

        private MBaseMessage VerifyCitizenMessage(VerifyCitizenIDModel model, string terminalId, DateTime processDateTime)
        {
            var headerTransaction = sQLService.GetHeaderTransaction(model.TranCode);
            HeaderMessageModel header = new HeaderMessageModel
            {
                InputLength = headerTransaction.InputLength,
                I13SSNO = headerTransaction.ScenarioNumber,
                I13TRCD = headerTransaction.MBaseTranCode,
                HDBRNO = model.BranchNumber,
                HDTXCD = headerTransaction.MBaseTranCode,
                HDACCD = headerTransaction.ActionMode,
                HDTMOD = headerTransaction.TransactionMode,
                HDNREC = headerTransaction.NoOfRecToRetrieve,
                I13TMID = terminalId,
                HDTMID = terminalId,
                HDRNUM = model.ReferenceNo,
                HDDTIN = processDateTime.ToString("ddMMyyyy"),
                HDTMIN = processDateTime.ToString("HHmmss")
            };
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            var inputMessages = sQLService.GetInputMessages(model.TranCode);
            var responseMessages = sQLService.GetResponseMessages(model.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
            };
        }
        private MBaseMessage CIFAccountCreationMessage(CIFCreateRequestModel cIFCreate, string terminalId, DateTime processDateTime)
        {
            // Header
            var headerTransaction = sQLService.GetHeaderTransaction(cIFCreate.TranCode);
            HeaderMessageModel header = new HeaderMessageModel
            {
                InputLength = headerTransaction.InputLength,
                I13SSNO = headerTransaction.ScenarioNumber,
                I13TRCD = headerTransaction.MBaseTranCode,
                HDBRNO = cIFCreate.BranchNumber,
                HDTXCD = headerTransaction.MBaseTranCode,
                HDACCD = headerTransaction.ActionMode,
                HDTMOD = headerTransaction.TransactionMode,
                HDNREC = headerTransaction.NoOfRecToRetrieve,
                I13TMID = terminalId,
                HDTMID = terminalId,
                HDRNUM = cIFCreate.ReferenceNo,
                HDDTIN = processDateTime.ToString("ddMMyyyy"),
                HDTMIN = processDateTime.ToString("HHmmss")
            };
            IEnumerable<MessageTypeModel> headerMessages = GetHeaderMessage(header);

            // Input
            var inputMessages = sQLService.GetInputMessages(cIFCreate.TranCode);
            inputMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName.Trim())
                {
                    case nameof(CIFAccount.TCFTTIT):
                        s.DefaultValue = cIFCreate.TitleThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1):
                        s.DefaultValue = cIFCreate.ThaiName;
                        break;
                    case nameof(CIFAccount.TCFNA1A):
                        s.DefaultValue = cIFCreate.ThaiSurename;
                        break;
                    case nameof(CIFAccount.TCFETIT):
                        s.DefaultValue = cIFCreate.TitleEngName;
                        break;
                    case nameof(CIFAccount.TCFASN1):
                        s.DefaultValue = cIFCreate.EngName;
                        break;
                    case nameof(CIFAccount.TCFASN2):
                        s.DefaultValue = cIFCreate.EngSurename;
                        break;
                    case nameof(CIFAccount.CFSSNO):
                        s.DefaultValue = cIFCreate.IDNumber;
                        break;
                    case nameof(CIFAccount.CFSSCD):
                        s.DefaultValue = cIFCreate.IDTypeCode;
                        break;
                    case nameof(CIFAccount.CFCIDT):
                        s.DefaultValue = cIFCreate.IDIssueCountryCode;
                        break;
                    case nameof(CIFAccount.BTCTYP):
                        s.DefaultValue = cIFCreate.CustomerType;
                        break;
                    case nameof(CIFAccount.BTMBTY):
                        s.DefaultValue = cIFCreate.MajorBusinessType;
                        break;
                    case nameof(CIFAccount.CFBRNN):
                        s.DefaultValue = cIFCreate.BranchNumber;
                        break;
                    case nameof(CIFAccount.CFCOST):
                        s.DefaultValue = cIFCreate.CostCenter;
                        break;
                    case nameof(CIFAccount.CFOFFR):
                        s.DefaultValue = cIFCreate.OfficerCode;
                        break;
                    case nameof(CIFAccount.CFBIR8):
                        s.DefaultValue = cIFCreate.BirthDate;
                        break;
                    case nameof(CIFAccount.CFRESD):
                        s.DefaultValue = cIFCreate.ResidentCode;
                        break;
                    case nameof(CIFAccount.CFCNTY):
                        s.DefaultValue = cIFCreate.Country;
                        break;
                    case nameof(CIFAccount.CFCITZ):
                        s.DefaultValue = cIFCreate.CountryOfCitizenship;
                        break;
                    case nameof(CIFAccount.CFRACE):
                        s.DefaultValue = cIFCreate.CountryOfHeritage;
                        break;
                    case nameof(CIFAccount.CFINQC):
                        s.DefaultValue = cIFCreate.InquiryCode;
                        break;
                    case nameof(CIFAccount.CFEMPL):
                        s.DefaultValue = cIFCreate.EmployerName;
                        break;
                    case nameof(CIFAccount.CFHPHO):
                        s.DefaultValue = cIFCreate.HomePhone;
                        break;
                    case nameof(CIFAccount.CFBPHO):
                        s.DefaultValue = cIFCreate.OfficePhone;
                        break;
                    case nameof(CIFAccount.CFBFHO):
                        s.DefaultValue = cIFCreate.OtherPhone;
                        break;
                    case nameof(CIFAccount.CFSEX):
                        s.DefaultValue = cIFCreate.Gender;
                        break;
                    case nameof(CIFAccount.CFSMSA):
                        s.DefaultValue = cIFCreate.SMSACode;
                        break;
                    case nameof(CIFAccount.CFBUST):
                        s.DefaultValue = cIFCreate.Occupation;
                        break;
                    case nameof(CIFAccount.CFSCLA):
                        s.DefaultValue = cIFCreate.SubClass;
                        break;
                    case nameof(CIFAccount.CFCRAT):
                        s.DefaultValue = cIFCreate.CustomerRating;
                        break;
                    case nameof(CIFAccount.CFGRUP):
                        s.DefaultValue = cIFCreate.CIFGroupCode;
                        break;
                    case nameof(CIFAccount.CFCCYC):
                        s.DefaultValue = cIFCreate.CIFCombinedCycle;
                        break;
                    case nameof(CIFAccount.CFTINS):
                        s.DefaultValue = cIFCreate.TINStatus;
                        break;
                    case nameof(CIFAccount.CFWHCD):
                        s.DefaultValue = cIFCreate.FedWHCode;
                        break;
                    case nameof(CIFAccount.CFWHPR):
                        s.DefaultValue = cIFCreate.StateWHCode;
                        break;
                    case nameof(CIFAccount.CFINSC):
                        s.DefaultValue = cIFCreate.InsiderCode;
                        break;
                    case nameof(CIFAccount.CFVIPC):
                        s.DefaultValue = cIFCreate.VIPCustomer;
                        break;
                    case nameof(CIFAccount.CFDEAD):
                        s.DefaultValue = cIFCreate.DeceasedCutomerFlag;
                        break;
                    case nameof(CIFAccount.CFBADA):
                        s.DefaultValue = cIFCreate.InsufficientAddress;
                        break;
                    case nameof(CIFAccount.CFHLDM):
                        s.DefaultValue = cIFCreate.HoldMailCode;
                        break;
                    case nameof(CIFAccount.CFFSD6):
                        s.DefaultValue = cIFCreate.CustomerReviewDate;
                        break;
                    case nameof(CIFAccount.CFSIC1):
                        s.DefaultValue = cIFCreate.SICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC2):
                        s.DefaultValue = cIFCreate.SICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC3):
                        s.DefaultValue = cIFCreate.SICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC4):
                        s.DefaultValue = cIFCreate.SICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC5):
                        s.DefaultValue = cIFCreate.SICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC6):
                        s.DefaultValue = cIFCreate.SICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC7):
                        s.DefaultValue = cIFCreate.SICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFSIC8):
                        s.DefaultValue = cIFCreate.SICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC1):
                        s.DefaultValue = cIFCreate.UICN1UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC2):
                        s.DefaultValue = cIFCreate.UICN2UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC3):
                        s.DefaultValue = cIFCreate.UICN3UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC4):
                        s.DefaultValue = cIFCreate.UICN4UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC5):
                        s.DefaultValue = cIFCreate.UICN5UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC6):
                        s.DefaultValue = cIFCreate.UICN6UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC7):
                        s.DefaultValue = cIFCreate.UICN7UserDefined;
                        break;
                    case nameof(CIFAccount.CFUIC8):
                        s.DefaultValue = cIFCreate.UICN8UserDefined;
                        break;
                    case nameof(CIFAccount.CFLGID):
                        s.DefaultValue = cIFCreate.LanguageIdentifier;
                        break;
                    case nameof(CIFAccount.CFRETN):
                        s.DefaultValue = cIFCreate.Retention;
                        break;
                    case nameof(CIFAccount.SSCODE):
                        s.DefaultValue = cIFCreate.DepositTypeCode;
                        break;
                    case nameof(CIFAccount.ACTYPE):
                        s.DefaultValue = cIFCreate.AccountType;
                        break;
                    case nameof(CIFAccount.TLBSRC):
                        s.DefaultValue = cIFCreate.SourceOfFunds;
                        break;
                    case nameof(CIFAccount.CRTAC):
                        s.DefaultValue = cIFCreate.CreateAccountFlag;
                        break;
                    case nameof(CIFAccount.CFENA1):
                        s.DefaultValue = cIFCreate.EmployerName01;
                        break;
                    case nameof(CIFAccount.CBINCC):
                        s.DefaultValue = cIFCreate.IncomeCapitalAmount;
                        break;
                    case nameof(CIFAccount.CFZTYP):
                        s.DefaultValue = cIFCreate.CompanyBusinessType;
                        break;
                    case nameof(CIFAccount.CFEDLV):
                        s.DefaultValue = cIFCreate.EducationLevel;
                        break;
                    case nameof(CIFAccount.CFEADD):
                        s.DefaultValue = cIFCreate.ElectronicAddress;
                        break;
                    case nameof(CIFAccount.CFFHNO):
                        s.DefaultValue = cIFCreate.HouseNo;
                        break;
                    case nameof(CIFAccount.CFFVNO):
                        s.DefaultValue = cIFCreate.VillageNo;
                        break;
                    case nameof(CIFAccount.CFFBLD):
                        s.DefaultValue = cIFCreate.Building;
                        break;
                    case nameof(CIFAccount.CFFALY):
                        s.DefaultValue = cIFCreate.Alley;
                        break;
                    case nameof(CIFAccount.CFFLAN):
                        s.DefaultValue = cIFCreate.Lane;
                        break;
                    case nameof(CIFAccount.CFFRD):
                        s.DefaultValue = cIFCreate.Road;
                        break;
                    case nameof(CIFAccount.CFFDIS):
                        s.DefaultValue = cIFCreate.SubDistrict;
                        break;
                    case nameof(CIFAccount.CFFCIT):
                        s.DefaultValue = cIFCreate.Distirict;
                        break;
                    case nameof(CIFAccount.CFFST):
                        s.DefaultValue = cIFCreate.Province;
                        break;
                    case nameof(CIFAccount.CFFZIP):
                        s.DefaultValue = cIFCreate.PostalCode;
                        break;
                }
            });

            // Response
            var responseMessages = sQLService.GetResponseMessages(cIFCreate.TranCode);

            return new MBaseMessage
            {
                HeaderTransaction = headerTransaction,
                HeaderMessages = headerMessages,
                InputMessages = inputMessages,
                ResponseMessages = responseMessages
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