using FATCAAPI.Interfaces;
using FATCAAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FATCAAPI.Controllers
{
    [Authorize]
    public class FatcaTHDescriptionController : ApiController
    {
        private readonly IAs400Service service;

        public FatcaTHDescriptionController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpGet]
        public FatcaTHDescriptionResponsneModel GetFatcaTHDescription()
        {

            return new FatcaTHDescriptionResponsneModel();
        }
    }
}
