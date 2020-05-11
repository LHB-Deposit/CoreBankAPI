using MBaseAccess;
using MBaseAccess.Entity;
using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public VerifyCitizenIDResponseModel VerifyCitizenID(VerifyCitizenIDModel model)
        {
            // Input Matching Object
            VerifyCitizenID verifyCitizen = new VerifyCitizenID();
            PropertyMatcher<VerifyCitizenIDModel, VerifyCitizenID>.GenerateMatchedObject(model, verifyCitizen);

            // MBase Verify Citizen ID
            var mBaseResponse = MBaseSingleton.Instance.VerifyCitizenID();

            // Output Matching Object
            VerifyCitizenIDResponseModel responseModel = new VerifyCitizenIDResponseModel();
            PropertyMatcher<VerifyCitizenIDResponse, VerifyCitizenIDResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
        public CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate, string terminalId, DateTime processDateTime)
        {
            cIFCreate = new CIFCreateRequestModel();

            var mBaseHeader = sQLService.GetMBaseHeader(cIFCreate.TranCode);
            var mBaseResponseMessages = sQLService.GetMBaseResponseMessages(cIFCreate.TranCode);
            var mBaseHeaderMessages = sQLService.GetMBaseHeaderMessages(cIFCreate.TranCode);
            var mBaseInputMessages = sQLService.GetMBaseInputMessages(cIFCreate.TranCode);
            var referenceNo = cIFCreate.ReferenceNo;

            MBaseMessage mBaseMessage = new MBaseMessage
            {
                Header = mBaseHeader,
                HeaderMessages = mBaseHeaderMessages,
                InputMessages = mBaseInputMessages,
                ResponseMessages = mBaseResponseMessages
            };

            // Input Matching Object
            CIFAccount cIFAccount = new CIFAccount();
            PropertyMatcher<CIFCreateRequestModel, CIFAccount>.GenerateMatchedObject(cIFCreate, cIFAccount);

            // MBase CIFCreate
            var mBaseResponse = MBaseSingleton.Instance.CIFCreation(cIFAccount, mBaseMessage, terminalId, referenceNo, processDateTime);

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