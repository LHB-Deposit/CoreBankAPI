using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class BaseRequestModel
    {
        [Required]
        [StringLength(23, MinimumLength = 23)]
        public string ReferenceNo { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string BranchNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string TerminalId { get; set; }
    }
}
