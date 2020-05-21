using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class ResponseMessage
    {
        [MatchParent("ErrorCode")]
        public string ErrorCode { get; set; }

        [MatchParent("ErrorDescription")]
        public string ErrorDescription { get; set; }
    }
}
