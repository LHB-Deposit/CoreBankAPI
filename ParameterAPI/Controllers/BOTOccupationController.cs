using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class BOTOccupationController : ApiController
    {
        private readonly IAs400Service service;
        public BOTOccupationController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/BOTOccupation
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetBOTOccupation(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuValue)].ToString()
            });
        }
    }
}
