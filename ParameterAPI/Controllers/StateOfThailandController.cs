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
    public class StateOfThailandController : ApiController
    {
        private readonly IAs400Service service;

        public StateOfThailandController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandValue)].ToString()
            };

            return service.GetState(appSettings);
        }
    }
}
