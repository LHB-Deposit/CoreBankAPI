using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class BusinessTypeController : ApiController
    {
        private readonly IParameterService service;
        public BusinessTypeController(IParameterService service)
        {
            this.service = service;
        }

        // GET: api/BusinessType
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetBusinessType(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.BusinessTypeFile)].ToString()
            });
        }
    }
}
