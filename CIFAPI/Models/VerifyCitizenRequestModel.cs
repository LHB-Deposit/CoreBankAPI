using SolutionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIFAPI.Models
{
    public class VerifyCitizenRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(4)]
        public string TranCode { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(15)]
        public string IDNumber { get; set; }

        [Required]
        [RegularExpression("^[A-Z]*$")]
        [StringLength(2)]
        public string IDTypeCode { get; set; }

        [Required]
        [RegularExpression("^[A-Z]*$")]
        [StringLength(3)]
        public string IDIssueCountryCode { get; set; }
    }
}