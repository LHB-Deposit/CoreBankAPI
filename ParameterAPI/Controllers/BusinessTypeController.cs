using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class BusinessTypeController : ApiController
    {
        private readonly IAs400Service service;
        public BusinessTypeController(IAs400Service service)
        {
            this.service = service;
        }

        // GET: api/BusinessType
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetBusinessType(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeValue)].ToString()
            });
        }
    }
}
