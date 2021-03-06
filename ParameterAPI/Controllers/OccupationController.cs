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
    public class OccupationController : ApiController
    {
        private readonly IAs400Service service;

        public OccupationController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.OccupationValue)].ToString()
            };
            return service.GetOccupation(appSetting);
        }
    }
}
