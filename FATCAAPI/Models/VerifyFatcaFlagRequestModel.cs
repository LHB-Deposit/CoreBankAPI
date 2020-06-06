using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace FATCAAPI.Models
{
    public class VerifyFatcaFlagRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        public string CustomerNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string CustomerId { get; set; }
    }
}