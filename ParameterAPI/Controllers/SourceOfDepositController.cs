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
    public class SourceOfDepositController : ApiController
    {
        private readonly IAs400Service service;

        public SourceOfDepositController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetSourceOfDeposit(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            });
        }

        [Route("api/SourceOfDeposit/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterModel> Corporate()
        {
            return service.GetSourceOfDepositCorp(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            });
        }
    }
}
