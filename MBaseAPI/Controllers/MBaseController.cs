using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MBaseAPI.Controllers
{
    [Authorize]
    public class MBaseController : ApiController
    {
        private readonly IMBaseService mBaseService;

        public MBaseController(IMBaseService mBaseService)
        {
            this.mBaseService = mBaseService;
        }

        // POST: api/MBase
        [HttpPost]
        public VerifyCitizenIDNumberResponse VerifyCitizenID([FromBody]VerifyCitizenIDNumber verifyCitizen)
        {


            return new VerifyCitizenIDNumberResponse
            {

            };
        }

        // POST: api/MBase
        [HttpPost]
        public CIFCreateResponseModel CIFCreate([FromBody]CIFCreateRequestModel cIFCreate)
        {
            cIFCreate = new CIFCreateRequestModel();
            return mBaseService.CIFCreation(cIFCreate);
        }

    }
}
