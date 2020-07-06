using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class SourceOfDepositController : ApiController
    {
        private readonly IAs400Service service;

        public SourceOfDepositController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };
            return service.GetSourceOfDeposit(appSetting);
        }

        [Route("api/SourceOfDeposit/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Corporate()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };
            return service.GetSourceOfDepositCorp(appSetting);
        }
    }
}
