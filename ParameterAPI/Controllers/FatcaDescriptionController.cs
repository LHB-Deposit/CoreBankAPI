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
        public IEnumerable<ParameterModel> Get(string lang = "EN")
        {
            string _value = string.Empty;
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
            return service.GetFatcaDescription(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATINH)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATINH)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.FatcaDescriptionKey)].ToString(),
                VALUE = _value
            });
        }
    }
}
