using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace iSeriesAPIService.Controllers
{
    public class DocumentTypeController : ApiController
    {
        private readonly IParameterService service;

        public DocumentTypeController(IParameterService service)
        {
            this.service = service;
        }
        // GET: api/DocumentType
        [HttpGet]
        public IEnumerable<ParameterModel> Get()
        {
            return service.GetDocumentType(new AppSettings
            {
                KEY = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeKey)].ToString(),
                VALUE = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeValue)].ToString(),
                FILE = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeFile)].ToString()
            });
        }
    }
}
