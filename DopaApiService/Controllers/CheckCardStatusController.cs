using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DopaApiService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DopaApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckCardStatusController : ControllerBase
    {
        private readonly IApiService apiService;

        public CheckCardStatusController(IApiService apiService)
        {
            this.apiService = apiService;
        }

        [HttpGet]
        public IEnumerable<string> CheckCardStatusByCID()
        {
            return new List<string> { };
        }
    }
}
