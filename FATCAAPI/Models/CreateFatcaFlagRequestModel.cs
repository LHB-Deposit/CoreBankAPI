using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace FATCAAPI.Models
{
    public class CreateFatcaFlagRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        public string CustomerNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(13)]
        public string CustomerId { get; set; }

        [Required]
        [RegularExpression("^(Y|N){1}")]
        public string Individual { get; set; }

        [Required]
        [RegularExpression("^(Y|N)[0-9]{2}")]
        public string FatcaCode { get; set; }

        [RegularExpression("^[A-Z]*$")]
        [StringLength(4)]
        public string Corporation { get; set; }

        [StringLength(15)]
        public string SSNITIN { get; set; }

        [StringLength(19)]
        public string GIIN { get; set; }

        [StringLength(10)]
        public string Username { get; set; }

    }
}