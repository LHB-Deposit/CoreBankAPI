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
        public CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate)
        {

            var cif = sQLService.GetMBaseTransaction("1732");


            CIFAccount cIFAccount = new CIFAccount();
            PropertyMatcher<CIFCreateRequestModel, CIFAccount>.GenerateMatchedObject(cIFCreate, cIFAccount);

            CIFAccountResponse mBaseResponse = MBaseSingleton.Instance.CIFCreation(cIFAccount,"","","","");
            
            CIFCreateResponseModel responseModel = new CIFCreateResponseModel();
            PropertyMatcher<CIFAccountResponse, CIFCreateResponseModel>.GenerateMatchedObject(mBaseResponse, responseModel);

            return responseModel;
        }
    }
}