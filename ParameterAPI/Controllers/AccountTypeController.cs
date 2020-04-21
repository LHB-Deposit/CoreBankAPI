using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class AccountTypeController : ApiController
    {
        private readonly IAs400Service _service;

        public AccountTypeController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBTDATINH)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATINH)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeValue)].ToString()
            };

            return _service.GetAccountType(appSettings);
        }
    }
}
