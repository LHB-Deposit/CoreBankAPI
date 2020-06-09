using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace ConsentAPI.Models
{
    public class VerifyConsentRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        public string CustomerNumber { get; set; }
    }
}