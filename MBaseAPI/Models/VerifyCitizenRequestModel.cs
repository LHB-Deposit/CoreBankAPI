using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace MBaseAPI.Models
{
    public class VerifyCitizenRequestModel : BaseRequestModel
    {
        [Required]
        [StringLength(4)]
        public string TranCode { get; set; }

        [Required]
        [StringLength(15)]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(2)]
        public string IDTypeCode { get; set; }

        [Required]
        [StringLength(3)]
        public string IDIssueCountryCode { get; set; }
    }
}