using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class EducationLevelController : ApiController
    {
        private readonly IAs400Service service;

        public EducationLevelController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/EducationLevel
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetEducationLevel(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelValue)].ToString()
            });
        }
    }
}
