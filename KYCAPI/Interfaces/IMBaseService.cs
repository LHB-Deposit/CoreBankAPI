using KYCAPI.Helpers;
using KYCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCAPI.Interfaces
{
    public interface IMBaseService
    {
        KycCIFLevelResponseModel CreateKycCIFLevel(KycCIFLevelRequestModel requestModel, DateTime processDateTime);
        KycAccountLevelResponseModel CreateKycAccountLevel(KycAccountLevelRequestModel requestModel, DateTime processDateTime);
        KycRiskLevelResponseModel CheckKycRiskLevel(KycRiskLevelRequestModel requestModel, AppSettings appSettings);
    }
}
