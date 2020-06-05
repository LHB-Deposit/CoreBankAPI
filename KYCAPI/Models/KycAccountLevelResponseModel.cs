using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYCAPI.Models
{
    public class KycAccountLevelResponseModel : BaseResponseModel
    {
        [MatchParent("KCATYP")]
        public string AccountType { get; set; }

        [MatchParent("KCACCN")]
        public string AccountNumber { get; set; }

        [MatchParent("DEPPURINV")]
        public string PurposeOfOpenAccount { get; set; }

        [MatchParent("DEPSRCINV")]
        public string SourceOfFund { get; set; }

        [MatchParent("KCSCOU")]
        public string SourceCountryOfFund { get; set; }

        [MatchParent("KCOPAM")]
        public string OpenAmount { get; set; }
    }
}