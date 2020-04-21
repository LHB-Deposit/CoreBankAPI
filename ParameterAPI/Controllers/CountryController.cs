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
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.CountryFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.CountryKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.CountryValue)].ToString()
            };

            return _service.GetCountry(appSettings);
        }
    }
}
