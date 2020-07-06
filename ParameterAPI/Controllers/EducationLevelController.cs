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
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.EduLevelValue)].ToString()
            };
            return service.GetEducationLevel(appSetting);
        }
    }
}
