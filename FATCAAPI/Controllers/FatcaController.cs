using FATCAAPI.Interfaces;
using FATCAAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FATCAAPI.Controllers
{
    public class FatcaController : ApiController
    {
        private readonly IAs400Service service;

        public FatcaController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<FatcaResponseModel> Get()
        {
            return service.Get();
        }
    }
}
