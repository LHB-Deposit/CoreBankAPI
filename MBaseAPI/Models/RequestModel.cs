using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class RequestModel
    {
        [Required]
        [MaxLength(7)]
        public string ReferenceNo { get; set; }

        [Required]
        [MaxLength(3)]
        public string BranchNumber { get; set; } = string.Empty;

        public string TerminalId { get; set; }
    }
}