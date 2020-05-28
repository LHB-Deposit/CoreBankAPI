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
        VerifyCitizenResponseModel VerifyCitizenID(VerifyCitizenRequestModel model, DateTime processDateTime);
        CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate, DateTime processDateTime);
        CIFAddressResponseModel CIFAddressCreate(CIFAddresRequestModel requestModel, DateTime processDateTime);
        KycCIFLevelResponseModel KycCIFLevelCreate(KycCIFLevelRequestModel requestModel, DateTime processDateTime);
        KycAccountLevelResponseModel KycAccountLevelCreate(KycAccountLevelRequestModel requestModel, DateTime processDateTime);
        void GetConfigMessages(MBaseParameterModel model);
    }
}
