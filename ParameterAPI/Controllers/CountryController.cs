using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class CountryController : ApiController
    {
        IAs400Service _service;

        public CountryController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                FILE = "SSCOUN",
                KEY = "SSCCOC",
                VALUE = "SSCTXT"
            };

            return _service.GetCountry(appSettings);
        }
    }
}
