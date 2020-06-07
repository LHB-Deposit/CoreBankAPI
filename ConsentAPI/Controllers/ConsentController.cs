using ConsentAPI.Interfaces;
using ConsentAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsentAPI.Controllers
{
    [Authorize]
    public class ConsentController : ApiController
    {
        private readonly IAs400Service service;

        public ConsentController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpPost]
        [ValidateModel]
        public VerifyConsentResponseModel VerifyConsent([FromBody] VerifyConsentRequestModel model)
        {
            return service.VerifyConsent(model);
        }

        [HttpPost]
        [ValidateModel]
        public CreateConsentResponseModel CreateConsent([FromBody] CreateConsentRequestModel model)
        {
            return service.CreateConsent(model);
        }
    }
}
