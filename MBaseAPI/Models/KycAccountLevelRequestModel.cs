using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace MBaseAPI.Models
{
    public class KycAccountLevelRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1633";

        [Required]
        [MaxLength(1)]
        [MatchParent("KCATYP")]
        public string AccountType { get; set; }

        [Required]
        [MaxLength(10)]
        [MatchParent("KCACCN")]
        public string AccountNumber { get; set; }

        [Required]
        [MaxLength(2)]
        [MatchParent("DEPPURINV")]
        public string PurposeOfOpenAccount { get; set; }

        [Required]
        [MaxLength(2)]
        [MatchParent("DEPSRCINV")]
        public string SourceOfFund { get; set; }

        [Required]
        [MaxLength(3)]
        [MatchParent("KCSCOU")]
        public string SourceCountryOfFund { get; set; }

        [Required]
        [MaxLength(9)]
        [MatchParent("KCOPAM")]
        public string OpenAmount { get; set; }
    }
}