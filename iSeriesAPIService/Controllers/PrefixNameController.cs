using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class PrefixNameController : ApiController
    {
        private readonly IParameterService service;

        public PrefixNameController(IParameterService service)
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
