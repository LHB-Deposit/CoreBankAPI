using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class PurposeOfAccountOpenController : ApiController
    {
        private readonly IAs400Service service;

        public PurposeOfAccountOpenController(IAs400Service service)
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
            return service.GetPurposeOfAccountOpen(appSetting);
        }

        [Route("api/PurposeOfAccountOpen/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Corporate()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };
            return service.GetPurposeOfAccountOpenCorp(appSetting);
        }
    }
}
