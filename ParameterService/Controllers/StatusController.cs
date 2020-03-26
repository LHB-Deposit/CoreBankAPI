using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ParameterAPIService.Helpers;
using ParameterAPIService.Interfaces;
using ParameterAPIService.Models;

namespace ParameterAPIService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public StatusController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetStatus(new ProjectAppSettings 
            {
                KEY = appSettings.StatusKey,
                VALUE = appSettings.StatusValue,
                FILE = appSettings.StatusFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}