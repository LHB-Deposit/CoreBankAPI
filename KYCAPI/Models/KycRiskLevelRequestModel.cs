using SolutionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYCAPI.Models
{
    public class KycRiskLevelRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        [MatchParent("KCCIFN")]
        public string CustomerNumber { get; set; }
    }
}