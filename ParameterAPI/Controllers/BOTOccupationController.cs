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
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuValue)].ToString()
            };
            return service.GetBOTOccupation(appSetting);
        }
    }
}
