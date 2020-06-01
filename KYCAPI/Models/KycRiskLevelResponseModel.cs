using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYCAPI.Models
{
    public class KycRiskLevelResponseModel : BaseResponseModel
    {
        public string CustomerNumber { get; set; } = string.Empty;

        public string RiskLevel { get; set; } = string.Empty;
    }
}