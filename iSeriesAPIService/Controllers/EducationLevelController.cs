using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class EducationLevelController : ApiController
    {
        private readonly IParameterService service;

        public EducationLevelController(IParameterService service)
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
