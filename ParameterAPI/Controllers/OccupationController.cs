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
    public class OccupationController : ApiController
    {
        private readonly IAs400Service service;

        public OccupationController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetOccupation(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationValue)].ToString()
            });
        }
    }
}
