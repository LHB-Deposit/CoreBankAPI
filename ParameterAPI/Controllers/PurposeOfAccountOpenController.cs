using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class PurposeOfAccountOpenController : ApiController
    {
        private readonly IAs400Service service;

        public PurposeOfAccountOpenController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetPurposeOfAccountOpen(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.KYCParameterValue)].ToString()
            });
        }

        [Route("api/PurposeOfAccountOpen/Corporate")]
        [HttpGet]
        public IEnumerable<ParameterModel> Corporate()
        {
            return service.GetPurposeOfAccountOpenCorp(new AppSettings
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
