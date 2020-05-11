using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class VerifyCitizenIDModel
    {
        [Required]
        [MaxLength(15)]
        public string IDNumber { get; set; }

        [Required]
        [MaxLength(2)]
        public string IDTypeCode { get; set; }

        [Required]
        [MaxLength(3)]
        public string IDIssueCountryCode { get; set; }
    }
}