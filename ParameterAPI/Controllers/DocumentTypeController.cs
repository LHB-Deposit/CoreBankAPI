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
        public IEnumerable<ParameterResponseModel> Get()
        {
            AS400AppSettingModel appSetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.DocTypeValue)].ToString()
            };
            return service.GetDocumentType(appSetting);
        }
    }
}
