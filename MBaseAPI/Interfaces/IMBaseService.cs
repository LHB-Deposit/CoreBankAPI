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
        VerifyCitizenIDResponseModel VerifyCitizenID(VerifyCitizenIDModel model, string terminalId, DateTime processDateTime);
        CIFCreateResponseModel CIFCreation(CIFCreateRequestModel cIFCreate, string terminalId, DateTime processDateTime);

        void GetMBaseMessages(MBaseParameterModel model);
    }
}
