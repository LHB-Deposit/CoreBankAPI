using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;

namespace MBaseAPI.Controllers
{
    [Authorize]
    public class MBaseController : ApiController
    {
        private readonly IMBaseService mBaseService;
        
        public MBaseController(IMBaseService mBaseService)
        {
            this.mBaseService = mBaseService;
        }

        // POST: api/MBase
        [HttpPost]
        public VerifyCitizenResponseModel VerifyCitizenID([FromBody]VerifyCitizenRequestModel model)
        {
            var terminalId = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString()).HostName.ToLower().Replace(".lhb.net", "");
            var processDatetime = DateTime.Now;
            return mBaseService.VerifyCitizenID(model, terminalId, processDatetime);
        }

        // POST: api/MBase
        [HttpPost]
        public CIFCreateResponseModel CIFCreate([FromBody]CIFCreateRequestModel model)
        {
            var terminalId = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString()).HostName.ToLower().Replace(".lhb.net", "");
            var processDatetime = DateTime.Now;
            return mBaseService.CIFCreation(model, terminalId, processDatetime);
        }

        // POST: api/MBase
        [HttpPost]
        public CIFAddressResponseModel CIFAddressCreate([FromBody]CIFAddresRequestModel model)
        {
            var terminalId = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString()).HostName.ToLower().Replace(".lhb.net", "");
            var processDatetime = DateTime.Now;
            return mBaseService.CIFAddressCreate(model, terminalId, processDatetime);
        }

        [HttpPost]
        public KycCIFLevelResponseModel KycCIFLevelCreate([FromBody]KycCIFLevelRequestModel model)
        {
            var terminalId = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString()).HostName.ToLower().Replace(".lhb.net", "");
            var processDatetime = DateTime.Now;
            return mBaseService.KycCIFLevelCreate(model, terminalId, processDatetime);
        }

        [HttpPost]
        public KycAccountLevelResponseModel KycAccountLevelCreate([FromBody]KycAccountLevelRequestModel model)
        {
            var terminalId = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString()).HostName.ToLower().Replace(".lhb.net", "");
            var processDatetime = DateTime.Now;
            return mBaseService.KycAccountLevelCreate(model, terminalId, processDatetime);
        }

        [Authorize(Roles = "Developer")]
        [HttpPost]
        public void FetchMBaseMessageForDevelopOnly([FromBody]MBaseParameterModel model)
        {
            mBaseService.GetConfigMessages(model);
        }
    }
}
