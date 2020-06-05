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
        [RegularExpression("(^[A-Z]{2}[0-9]{21})")]
        public string ReferenceNo { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(3, MinimumLength = 3)]
        public string BranchNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string TerminalId { get; set; }
    }
}
