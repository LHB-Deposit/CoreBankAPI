using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
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
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.StatusKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusValue)].ToString()
            });
        }
    }
}
