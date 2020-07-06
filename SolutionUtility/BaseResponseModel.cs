using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class BaseResponseModel
    {
        [MatchParent("ErrorCode")]
        public string ErrorCode { get; set; } = string.Empty;

        [MatchParent("ErrorDescription")]
        public string ErrorDescription { get; set; } = string.Empty;

        public string ReferenceNo { get; set; }
    }
}
