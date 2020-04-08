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

        public MBaseService(ISQLService sQLService)
        {
            this.sQLService = sQLService;
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

            // Matching Object
            CIFAccount cIFAccount = new CIFAccount();
            PropertyMatcher<CIFCreateRequestModel, CIFAccount>.GenerateMatchedObject(cIFCreate, cIFAccount);

            // MBase CIFCreate
            CIFAccountResponse mBaseResponse = MBaseSingleton.Instance.CIFCreation(cIFAccount, mBaseMessage, terminalId, referenceNo, processDateTime);

            // Matching Object
            CIFCreateResponseModel responseModel = new CIFCreateResponseModel();
            PropertyMatcher<CIFAccountResponse, CIFCreateResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
    }
}