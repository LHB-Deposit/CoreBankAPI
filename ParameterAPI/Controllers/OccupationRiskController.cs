﻿using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class OccupationRiskController : ApiController
    {
        private readonly IAs400Service service;

        public OccupationRiskController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/OccupationRisk
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetOccupationRisk(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskValue)].ToString()
            });
        }
    }
}
