using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace ConsentAPI.Models
{
    public class CreateConsentRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        public string CustomerNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string DocumentType { get; set; }

        [Required]
        [StringLength(10)]
        public string DocumentCode { get; set; }

        [Required]
        [RegularExpression("^(Y|N)*$")]
        [StringLength(1)]
        public string ConsentFlag { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(10)]
        public string User { get; set; }
    }
}