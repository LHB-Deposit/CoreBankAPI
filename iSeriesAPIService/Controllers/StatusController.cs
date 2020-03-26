using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class StatusController : ApiController
    {
        private readonly IParameterService service;

        public StatusController(IParameterService service)
        {
            this.service = service;
        }
        // GET: api/Status
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetStatus(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.StatusKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.StatusFile)].ToString()
            });
        }
    }
}
