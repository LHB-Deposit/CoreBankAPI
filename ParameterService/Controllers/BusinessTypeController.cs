using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ParameterAPIService.Helpers;
using ParameterAPIService.Interfaces;
using ParameterAPIService.Models;

namespace ParameterAPIService.Collections
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public BusinessTypeController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetBusinessType(new ProjectAppSettings 
            {
                KEY = appSettings.BusinessTypeKey,
                VALUE = appSettings.BusinessTypeValue,
                FILE = appSettings.BusinessTypeFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}