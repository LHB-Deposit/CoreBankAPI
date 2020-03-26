using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
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
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelFile)].ToString()
            });
        }
    }
}
