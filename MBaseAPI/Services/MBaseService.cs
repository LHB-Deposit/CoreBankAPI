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
            var mBaseHeader = sQLService.GetMBaseHeader(model.TranCode);
            var mBaseResponseMessages = sQLService.GetMBaseResponseMessages(model.TranCode);
            var mBaseHeaderMessages = sQLService.GetMBaseHeaderTransaction();
            mBaseHeaderMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName)
                {
                    case nameof(MBaseHeader.SKTMLEN):
                        s.DefaultValue = ((MBaseSingleton.Instance.HeaderMessageLength + mBaseHeader.InputLength) - 4).ToString();
                        break;
                    case nameof(MBaseHeader.SKTDEVN):
                        s.DefaultValue = MBaseSingleton.Instance.ServerHost;
                        break;
                    case nameof(MBaseHeader.SKTSKNB):
                        s.DefaultValue = "2";
                        break;
                    case nameof(MBaseHeader.SKTPORT):
                        s.DefaultValue = MBaseSingleton.Instance.ServerPort.ToString();
                        break;
                    case nameof(MBaseHeader.I13SSNO):
                        s.DefaultValue = mBaseHeader.ScenarioNumber;
                        break;
                    case nameof(MBaseHeader.I13TRCD):
                        s.DefaultValue = mBaseHeader.MBaseTranCode;
                        break;
                    case nameof(MBaseHeader.I13USER):
                        s.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeader.HDUSID):
                        s.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeader.HDSRID):
                        s.DefaultValue = "EFP";
                        break;
                    case nameof(MBaseHeader.HDBKNO):
                        s.DefaultValue = "73";
                        break;
                    case nameof(MBaseHeader.HDBRNO):
                        s.DefaultValue = "800".PadLeft(5, '0');
                        break;
                    case nameof(MBaseHeader.HDTXCD):
                        s.DefaultValue = mBaseHeader.MBaseTranCode;
                        break;
                    case nameof(MBaseHeader.HDACCD):
                        s.DefaultValue = mBaseHeader.ActionMode;
                        break;
                    case nameof(MBaseHeader.HDTMOD):
                        s.DefaultValue = mBaseHeader.TransactionMode;
                        break;
                    case nameof(MBaseHeader.HDNREC):
                        s.DefaultValue = mBaseHeader.NoOfRecToRetrieve;
                        break;
                    case nameof(MBaseHeader.I13TMID):
                        s.DefaultValue = terminalId;
                        break;
                    case nameof(MBaseHeader.HDTMID):
                        s.DefaultValue = terminalId;
                        break;
                    case nameof(MBaseHeader.HDRNUM):
                        s.DefaultValue = model.ReferenceNo;
                        break;
                    case nameof(MBaseHeader.HDDTIN):
                        s.DefaultValue = DateTime.Now.ToString("ddMMyyyy");
                        break;
                    case nameof(MBaseHeader.HDTMIN):
                        s.DefaultValue = DateTime.Now.ToString("HHmmss");
                        break;
                }
            });


            var mBaseInputMessages = sQLService.GetMBaseInputMessages(model.TranCode);

            MBaseMessage mBaseMessage = new MBaseMessage
            {
                Header = mBaseHeader,
                HeaderMessages = mBaseHeaderMessages,
                InputMessages = mBaseInputMessages,
                ResponseMessages = mBaseResponseMessages
            };

            // For test Debug values
            List<string> headerMessageValues = new List<string>();
            mBaseHeaderMessages.ForEach(s =>
            {
                headerMessageValues.Add($"[{s.FieldName }: { s.DefaultValue }]");
            });
            Logging.WriteLog(string.Join(Environment.NewLine, headerMessageValues));

            // End Debug Values

            // Input Matching Object
            VerifyCitizenID verifyCitizen = new VerifyCitizenID();
            PropertyMatcher<VerifyCitizenIDModel, VerifyCitizenID>.GenerateMatchedObject(model, verifyCitizen);

            // MBase Verify Citizen ID
            var mBaseResponse = MBaseSingleton.Instance.VerifyCitizenID(verifyCitizen, mBaseMessage);

            // Output Matching Object
            VerifyCitizenIDResponseModel responseModel = new VerifyCitizenIDResponseModel();
            PropertyMatcher<VerifyCitizenIDResponse, VerifyCitizenIDResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate, string terminalId, DateTime processDateTime)
        {
            //cIFCreate = new CIFCreateRequestModel();

            var mBaseHeader = sQLService.GetMBaseHeader(cIFCreate.TranCode);
            var mBaseResponseMessages = sQLService.GetMBaseResponseMessages(cIFCreate.TranCode);
            var mBaseHeaderMessages = sQLService.GetMBaseHeaderTransaction();
            mBaseHeaderMessages.ToList().ForEach(s =>
            {
                switch (s.FieldName)
                {
                    case nameof(MBaseHeader.SKTMLEN):
                        s.DefaultValue = ((MBaseSingleton.Instance.HeaderMessageLength + mBaseHeader.InputLength) - 4).ToString();
                        break;
                    case nameof(MBaseHeader.SKTDEVN):
                        s.DefaultValue = MBaseSingleton.Instance.ServerHost;
                        break;
                    case nameof(MBaseHeader.SKTSKNB):
                        s.DefaultValue = "2";
                        break;
                    case nameof(MBaseHeader.SKTPORT):
                        s.DefaultValue = MBaseSingleton.Instance.ServerPort.ToString();
                        break;
                    case nameof(MBaseHeader.I13SSNO):
                        s.DefaultValue = mBaseHeader.ScenarioNumber;
                        break;
                    case nameof(MBaseHeader.I13TRCD):
                        s.DefaultValue = mBaseHeader.MBaseTranCode;
                        break;
                    case nameof(MBaseHeader.I13USER):
                        s.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeader.HDUSID):
                        s.DefaultValue = "LHD8899201";
                        break;
                    case nameof(MBaseHeader.HDSRID):
                        s.DefaultValue = "EFP";
                        break;
                    case nameof(MBaseHeader.HDBKNO):
                        s.DefaultValue = "73";
                        break;
                    case nameof(MBaseHeader.HDBRNO):
                        s.DefaultValue = "800".PadLeft(5, '0');
                        break;
                    case nameof(MBaseHeader.HDTXCD):
                        s.DefaultValue = mBaseHeader.MBaseTranCode;
                        break;
                    case nameof(MBaseHeader.HDACCD):
                        s.DefaultValue = mBaseHeader.ActionMode;
                        break;
                    case nameof(MBaseHeader.HDTMOD):
                        s.DefaultValue = mBaseHeader.TransactionMode;
                        break;
                    case nameof(MBaseHeader.HDNREC):
                        s.DefaultValue = mBaseHeader.NoOfRecToRetrieve;
                        break;
                    case nameof(MBaseHeader.I13TMID):
                        s.DefaultValue = terminalId;
                        break;
                    case nameof(MBaseHeader.HDTMID):
                        s.DefaultValue = terminalId;
                        break;
                    case nameof(MBaseHeader.HDRNUM):
                        s.DefaultValue = cIFCreate.ReferenceNo;
                        break;
                    case nameof(MBaseHeader.HDDTIN):
                        s.DefaultValue = DateTime.Now.ToString("ddMMyyyy");
                        break;
                    case nameof(MBaseHeader.HDTMIN):
                        s.DefaultValue = DateTime.Now.ToString("HHmmss");
                        break;
                }
            });
            

            var mBaseInputMessages = sQLService.GetMBaseInputMessages(cIFCreate.TranCode);

            MBaseMessage mBaseMessage = new MBaseMessage
            {
                Header = mBaseHeader,
                HeaderMessages = mBaseHeaderMessages,
                InputMessages = mBaseInputMessages,
                ResponseMessages = mBaseResponseMessages
            };

            // For test Debug values
            List<string> headerMessageValues = new List<string>();
            mBaseHeaderMessages.ForEach(s =>
            {
                headerMessageValues.Add($"[{s.FieldName }: { s.DefaultValue }]");
            });
            Logging.WriteLog(string.Join(Environment.NewLine, headerMessageValues));

            // End Debug Values

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFCreation(mBaseMessage);

            // Output Matching Object
            CIFCreateResponseModel responseModel = new CIFCreateResponseModel();
            PropertyMatcher<CIFAccountResponse, CIFCreateResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }

        public void GetMBaseMessages(MBaseParameterModel parameterModel)
        {
            var mBaseMessageType = as400Service.GetMBaseMessages(parameterModel);
            foreach (var message in mBaseMessageType)
            {
                sQLService.AddMBaseMessage(message);
            }
            
        }


    }
}