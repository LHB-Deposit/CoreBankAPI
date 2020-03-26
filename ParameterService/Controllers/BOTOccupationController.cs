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

    [Route("api/[controller]")]
    [ApiController]
    public class BOTOccupationController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public BOTOccupationController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }
        // GET: api/Occupation
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetBOTOccupation(new ProjectAppSettings 
            {
                KEY = appSettings.BOTOccuKey,
                VALUE = appSettings.BOTOccuValue,
                FILE = appSettings.BOTOccuFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}
