using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class SourceOfIncomeController : ApiController
    {
        IAs400Service _service;

        public SourceOfIncomeController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                FILE = "CFPAR9",
                KEY = "CP9XCD",// Recheck again
                VALUE = "CP9DSC"                
            };

            return _service.GetSourceOfIncome(appSettings);
        }
    }
}
