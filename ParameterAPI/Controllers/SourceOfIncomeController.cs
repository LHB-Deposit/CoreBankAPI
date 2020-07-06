using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class SourceOfIncomeController : ApiController
    {
        private readonly IAs400Service _service;

        public SourceOfIncomeController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };

            return _service.GetSourceOfIncome(appSettings);
        }

        [Route("api/SourceOfIncome/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Corporate()
        {
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };

            return _service.GetSourceOfIncomeCorp(appSettings);
        }
    }
}
