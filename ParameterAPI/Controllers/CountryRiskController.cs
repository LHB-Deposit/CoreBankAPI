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
    public class CountryRiskController : ApiController
    {
        private readonly IAs400Service service;

        public CountryRiskController(IAs400Service service)
        {
            this.service = service;
        }

        // GET: api/CountryRisk
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.CountryRiskFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.CountryRiskKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.CountryRiskValue)].ToString()
            };
            return service.GetCountryRisk(appSetting);
        }
    }
}
