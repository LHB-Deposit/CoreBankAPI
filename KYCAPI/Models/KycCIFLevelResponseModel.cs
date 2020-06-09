using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYCAPI.Models
{
    public class KycCIFLevelResponseModel : BaseResponseModel
    {
        [MatchParent("KCCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("KCFRKL")]
        public string PreviousRiskLevel { get; set; }

        [MatchParent("KCRRKL")]
        public string ReiskLevel { get; set; }

        [MatchParent("KCLRDT")]
        public string LastReviewDate { get; set; }

        [MatchParent("KCNRDT")]
        public string NextReviewDate { get; set; }

        [MatchParent("WDTEXT")]
        public string PEPList { get; set; }
    }
}