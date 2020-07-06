using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class BusinessTypeController : ApiController
    {
        private readonly IAs400Service service;
        public BusinessTypeController(IAs400Service service)
        {
            this.service = service;
        }

        // GET: api/BusinessType
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeValue)].ToString()
            };
            return service.GetBusinessType(appSetting);
        }
    }
}
