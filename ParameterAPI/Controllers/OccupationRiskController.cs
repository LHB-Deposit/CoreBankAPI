using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class OccupationRiskController : ApiController
    {
        private readonly IAs400Service service;

        public OccupationRiskController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/OccupationRisk
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskValue)].ToString()
            };
            return service.GetOccupationRisk(appSetting);
        }
    }
}
