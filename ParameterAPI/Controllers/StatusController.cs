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
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.StatusFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.StatusKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.StatusValue)].ToString()
            };
            return service.GetStatus(appSetting);
        }
    }
}
