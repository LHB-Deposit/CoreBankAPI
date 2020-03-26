using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    public class PrefixNameController : ApiController
    {
        private readonly IAs400Service service;

        public PrefixNameController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/PrefixName
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetPrefixName(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.PrefixNameFile)].ToString()
            });
        }
    }
}
