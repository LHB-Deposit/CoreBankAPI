using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATCAAPI.Models
{
    public class VerifyFatcaFlagResponseModel : BaseResponseModel
    {
        public string CustomerNumber { get; set; }
        public string FatcaFlag { get; set; } = string.Empty;
        public string FatcaCode { get; set; } = string.Empty;
    }
}