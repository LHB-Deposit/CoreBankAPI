using CIFAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFAPI.Interfaces
{
    public interface IMBaseService
    {
        VerifyCitizenResponseModel VerifyCitizenID(VerifyCitizenRequestModel model, DateTime processDateTime);
        CreateCifAndAccountResponseModel CreateCifAndAccount(CreateCifAndAccountRequestModel cIFCreate, DateTime processDateTime);
        CreateCifAddressResponseModel CreateCifAddress(CreateCifAddresRequestModel requestModel, DateTime processDateTime);
    }
}
