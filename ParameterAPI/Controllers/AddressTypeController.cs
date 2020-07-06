using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class AddressTypeController : ApiController
    {
        private readonly IAs400Service service;

        public AddressTypeController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSettings = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.AddressTypeFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.AddressTypeKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.AddressTypeValue)].ToString()
            };

            return service.GetAddressType(appSettings);
        }
    }
}
