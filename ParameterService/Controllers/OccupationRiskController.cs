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
    public class OccupationRiskController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public OccupationRiskController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetOccupationRisk(new ProjectAppSettings 
            {
                KEY = appSettings.OccRiskKey,
                VALUE = appSettings.OccRiskValue,
                FILE = appSettings.OccRiskFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}