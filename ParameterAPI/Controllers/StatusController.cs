using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    public class StatusController : ApiController
    {
        private readonly IAs400Service service;

        public StatusController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/Status
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetStatus(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.StatusKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusFile)].ToString()
            });
        }
    }
}
