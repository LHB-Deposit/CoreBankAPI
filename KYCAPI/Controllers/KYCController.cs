using KYCAPI.Interfaces;
using KYCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KYCAPI.Controllers
{
    [Authorize]
    public class KYCController : ApiController
    {
        private readonly IAs400Service service;

        public KYCController(IAs400Service service)
        {
            this.service = service;
        }
        // POST: api/KYC
        [HttpPost]
        public void Post([FromBody]CIFLevelRequestModel requestModel)
        {

        }

    }
}
