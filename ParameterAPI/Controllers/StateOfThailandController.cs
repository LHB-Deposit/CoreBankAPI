﻿using ParameterAPI.Helpers;
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
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.StateOfThailandValue)].ToString()
            };

            return service.GetState(appSettings);
        }
    }
}