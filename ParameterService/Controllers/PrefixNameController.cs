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
    public class PrefixNameController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public PrefixNameController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetPrefixName(new ProjectAppSettings 
            {
                KEY = appSettings.PrefixNameKey,
                VALUE = appSettings.PrefixNameValue,
                FILE = appSettings.PrefixNameFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}