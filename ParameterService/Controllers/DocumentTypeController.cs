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
    public class DocumentTypeController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IParameterServices services;
        public DocumentTypeController(IOptions<AppSettings> appSettings, IParameterServices services)
        {
            this.appSettings = appSettings.Value;
            this.services = services;
        }

        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return services.GetDocumentType(new ProjectAppSettings 
            {
                KEY = appSettings.DocTypeKey,
                VALUE = appSettings.DocTypeValue,
                FILE = appSettings.DocTypeFile,
                ISTEST = appSettings.ISTEST,
                LHBDDATPAR = appSettings.LHBDDATPAR,
                LHBPDATPAR = appSettings.LHBPDATPAR
            });
        }
    }
}