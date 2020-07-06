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
        public IEnumerable<ParameterResponseModel> Get(string lang = "EN")
        {
            string _value;
            switch (lang)
            {
                case "TH":
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeTHValue)].ToString();
                    break;
                case "EN":
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeENValue)].ToString();
                    break;
                default:
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeENValue)].ToString();
                    break;
            }
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.AccountTypeKey)].ToString(),
                Value = _value
            };

            return _service.GetAccountType(appSettings);
        }
    }
}
