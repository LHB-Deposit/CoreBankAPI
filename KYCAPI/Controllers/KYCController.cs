using KYCAPI.Helpers;
using KYCAPI.Interfaces;
using KYCAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KYCAPI.Controllers
{
    //[Authorize]
    public class KYCController : ApiController
    {
        private readonly IMBaseService mBaseService;

        public KYCController(IMBaseService mBaseService)
        {
            this.mBaseService = mBaseService;
        }

        // POST: api/KYC
        [HttpPost]
        [ValidateModel]
        public KycCIFLevelResponseModel CreateKycCIFLevel([FromBody]KycCIFLevelRequestModel model)
        {
            var processDatetime = DateTime.Now;
            return mBaseService.CreateKycCIFLevel(model, processDatetime);
        }

        [HttpPost]
        [ValidateModel]
        public KycAccountLevelResponseModel CreateKycAccountLevel([FromBody]KycAccountLevelRequestModel model)
        {
            var processDatetime = DateTime.Now;
            return mBaseService.CreateKycAccountLevel(model, processDatetime);
        }

        [HttpPost]
        [ValidateModel]
        public KycRiskLevelResponseModel KycRiskLevel([FromBody]KycRiskLevelRequestModel model)
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATMAS)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATMAS)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KCMAST)].ToString()
            };
            return mBaseService.CheckKycRiskLevel(model, appSettings);
        }

    }
}
