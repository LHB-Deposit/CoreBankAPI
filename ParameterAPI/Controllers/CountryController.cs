using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class CountryController : ApiController
    {
        private readonly IAs400Service _service;

        public CountryController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.CountryFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.CountryKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.CountryValue)].ToString()
            };

            return _service.GetCountry(appSettings);
        }
    }
}
