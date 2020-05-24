using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class KycCIFLevelResponse
    {
        [MatchParent("CustomerNumber")]
        public string KCCIFN { get; set; }

        [MatchParent("PreviousRiskLevel")]
        public string KCFRKL { get; set; }

        [MatchParent("RiskLevel")]
        public string KCRRKL { get; set; }

        [MatchParent("LastReviewDate")]
        public string KCLRDT { get; set; }

        [MatchParent("NextReviewDate")]
        public string KCNRDT { get; set; }

        [MatchParent("PEPList")]
        public string WDTEXT { get; set; }
    }
}
