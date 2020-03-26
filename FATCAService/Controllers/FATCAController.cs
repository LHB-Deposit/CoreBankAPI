using System.Collections.Generic;
using System.Data;
using DataAccess;
using FATCAAPIService.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FATCAAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FATCAController : ControllerBase
    {
        private AppSettings _appSettings;

        public FATCAController(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }
        // GET: api/FATCA
        [HttpGet]
        public IEnumerable<string> Get()
        {
            DataTable dt = new DataTable();
            string oMessage;
            AS400Singleton.AS400.ExecuteSql("", out dt, out oMessage);
            return new string[] { "value1", "value2" };
        }
    }
}
