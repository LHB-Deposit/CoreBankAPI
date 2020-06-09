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
    public class CreateController : ApiController
    {
        private readonly IAs400Service service;

        public CreateController(IAs400Service service)
        {
            this.service = service;
        }
        // POST: api/Create
        [HttpPost]
        public IHttpActionResult Post([FromBody]CIFRequestModel model)
        {

            return Ok();
        }

    }
}
