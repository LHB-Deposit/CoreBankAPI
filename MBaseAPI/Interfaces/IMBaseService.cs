using MBaseAccess.Entity;
using MBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAPI.Interfaces
{
    public interface IMBaseService
    {
        VerifyCitizenResponseModel VerifyCitizenID(VerifyCitizenRequestModel model, string terminalId, DateTime processDateTime);
        CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate, string terminalId, DateTime processDateTime);
        CIFAddressResponseModel CIFAddressCreate(CIFAddresRequestModel requestModel, string terminalId, DateTime processDateTime);
        KycCIFLevelResponseModel KycCIFLevelCreate(KycCIFLevelRequestModel requestModel, string terminalId, DateTime processDateTime);
        KycAccountLevelResponseModel KycAccountLevelCreate(KycAccountLevelRequestModel requestModel, string terminalId, DateTime processDateTime);
        void GetConfigMessages(MBaseParameterModel model);
    }
}
