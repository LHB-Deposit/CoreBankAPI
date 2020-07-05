using CIFAPI.Interfaces;
using CIFAPI.Models;
using SolutionUtility;
using System;
using System.Web.Http;

namespace CIFAPI.Controllers
{
    //[Authorize]
    public class CIFController : ApiController
    {
        private readonly IMBaseService mBaseService;

        public CIFController(IMBaseService mBaseService)
        {
            this.mBaseService = mBaseService;
        }

        // POST: api/MBase
        [HttpPost]
        [ValidateModel]
        public VerifyCitizenResponseModel VerifyCitizenID([FromBody] VerifyCitizenRequestModel model)
        {
            var processDatetime = DateTime.Now;
            return mBaseService.VerifyCitizenID(model, processDatetime);
        }

        // POST: api/MBase
        [HttpPost]
        [ValidateModel]
        public CreateCifAndAccountResponseModel CreateCifAndAccount([FromBody] CreateCifAndAccountRequestModel model)
        {
            var processDatetime = DateTime.Now;
            return mBaseService.CreateCifAndAccount(model, processDatetime);
        }

        // POST: api/MBase
        [HttpPost]
        [ValidateModel]
        public CreateCifAddressResponseModel CreateCifAddress([FromBody] CreateCifAddresRequestModel model)
        {
            var processDatetime = DateTime.Now;
            
            return mBaseService.CreateCifAddress(model, processDatetime);
        }
    }
}
