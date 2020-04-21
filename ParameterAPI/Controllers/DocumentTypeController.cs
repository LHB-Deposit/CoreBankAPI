using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace ParameterAPI.Controllers
{
    [Authorize]
    public class DocumentTypeController : ApiController
    {
        private readonly IAs400Service service;

        public DocumentTypeController(IAs400Service service)
        {
            this.service = service;
        }
        // GET: api/DocumentType
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetDocumentType(new AppSettings
            {
                LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                    ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                    : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString(),

                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeFile)].ToString(),
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeValue)].ToString()
            });
        }
    }
}
