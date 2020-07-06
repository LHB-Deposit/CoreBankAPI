using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class PrefixNameController : ApiController
    {
        private readonly IAs400Service service;

        public PrefixNameController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/PrefixName
        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameValue)].ToString()
            };
            return service.GetPrefixName(appSetting);
        }
    }
}
