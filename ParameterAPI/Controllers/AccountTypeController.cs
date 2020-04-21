using iSeriesAPIService.Models;
using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    public class AccountTypeController : ApiController
    {
        IAs400Service _service;

        public AccountTypeController(IAs400Service service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            AppSettings appSettings = new AppSettings()
            {
                as400List = new List<AS400Model>() { },
                KEY = "FACTYPE",
                VALUE = "FNAMEEN"
            };

            appSettings.as400List.Add(new AS400Model()
            {
                Library = ConfigurationManager.AppSettings[nameof(AppSettings.LHB_DATINH)].ToString(),
                File = "DPI2392F"
            });

            return _service.GetAccountType(appSettings);
        }
    }
}
