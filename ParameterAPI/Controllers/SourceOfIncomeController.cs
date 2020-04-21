﻿using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class SourceOfIncomeController : ApiController
    {
        private readonly IAs400Service _service;

        public SourceOfIncomeController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };

            return _service.GetSourceOfIncome(appSettings);
        }

        [Route("api/SourceOfIncome/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterModel> Corporate()
        {
            AppSettings appSettings = new AppSettings()
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            };

            return _service.GetSourceOfIncomeCorp(appSettings);
        }
    }
}