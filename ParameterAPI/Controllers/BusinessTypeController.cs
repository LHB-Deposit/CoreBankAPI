using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
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
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeFile)].ToString()
            });
        }
    }
}
