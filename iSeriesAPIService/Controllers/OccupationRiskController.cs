using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class OccupationRiskController : ApiController
    {
        private readonly IParameterService service;

        public OccupationRiskController(IParameterService service)
        {
            this.service = service;
        }
        // GET: api/OccupationRisk
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetOccupationRisk(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.OccRiskFile)].ToString()
            });
        }
    }
}
