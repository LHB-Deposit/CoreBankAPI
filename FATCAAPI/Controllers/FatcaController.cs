﻿using FATCAAPI.Helpers;
using FATCAAPI.Interfaces;
using FATCAAPI.Models;
using SolutionUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FATCAAPI.Controllers
{
    [Authorize]
    public class FatcaController : ApiController
    {
        private readonly IAs400Service service;

        public FatcaController(IAs400Service service)
        {
            this.service = service;
        }

        [HttpPost]
        [ValidateModel]
        public VerifyFatcaFlagResponseModel VerifyFatcaFlag([FromBody] VerifyFatcaFlagRequestModel model)
        {
            return service.VerifyFatcaFlag(model);
        }

        [HttpPost]
        [ValidateModel]
        public CreateFatcaFlagResponseModel CreateFatcaFlag([FromBody] CreateFatcaFlagRequestModel model)
        {
            return service.CreateFatcaFlag(model);
        }


    }
}
