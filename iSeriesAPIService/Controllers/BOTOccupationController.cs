using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class BOTOccupationController : ApiController
    {
        private readonly IParameterService service;
        public BOTOccupationController(IParameterService service)
        {
            this.service = service;
        }
        // GET: api/BOTOccupation
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetBOTOccupation(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.BOTOccuFile)].ToString()
            });
        }
    }
}
