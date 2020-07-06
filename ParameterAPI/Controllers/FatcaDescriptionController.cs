using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class FatcaDescriptionController : ApiController
    {
        private readonly IAs400Service service;

        public FatcaDescriptionController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/Status
        [HttpGet()]
        public IEnumerable<ParameterResponseModel> Get(string lang = "EN")
        {
            string _value;
            switch (lang)
            {
                case "TH":
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionTHValue)].ToString();
                    break;
                case "EN":
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionENValue)].ToString();
                    break;
                default:
                    _value = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionENValue)].ToString();
                    break;
            }

            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionKey)].ToString(),
                Value = _value
            };
            return service.GetFatcaDescription(appSetting);
        }
    }
}
