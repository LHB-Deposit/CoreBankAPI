using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace MBaseAPI.Models
{
    public class KycAccountLevelRequestModel : BaseRequestModel
    {
        public string TranCode { get; set; } = "1633";

        [Required]
        [StringLength(1)]
        [MatchParent("KCATYP")]
        public string AccountType { get; set; }

        [Required]
        [StringLength(10)]
        [MatchParent("KCACCN")]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(2)]
        [MatchParent("DEPPURINV")]
        public string PurposeOfOpenAccount { get; set; }

        [Required]
        [StringLength(2)]
        [MatchParent("DEPSRCINV")]
        public string SourceOfFund { get; set; }

        [Required]
        [StringLength(3)]
        [MatchParent("KCSCOU")]
        public string SourceCountryOfFund { get; set; }

        [Required]
        [StringLength(9)]
        [MatchParent("KCOPAM")]
        public string OpenAmount { get; set; }
    }
}