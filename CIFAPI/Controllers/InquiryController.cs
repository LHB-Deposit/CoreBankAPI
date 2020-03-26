using CIFAPI.Interfaces;
using CIFAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CIFAPI.Controllers
{
    public class InquiryController : ApiController
    {
        private readonly IAs400Service service;

        public InquiryController(IAs400Service service)
        {
            this.service = service;
        }
        // POST: api/Inquiry
        [HttpPost]
        public IHttpActionResult Post([FromBody]CIFRequestModel model)
        {

            return Ok();
        }

    }
}
