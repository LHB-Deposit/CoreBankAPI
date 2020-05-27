using SolutionUtility;

namespace MBaseAPI.Models
{
    public class KycAccountLevelRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1633";
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