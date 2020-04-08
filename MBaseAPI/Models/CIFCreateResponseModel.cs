using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFCreateResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; } = string.Empty;

        [MatchParent("ACCTNO")]
        public string AccountNumber { get; set; } = string.Empty;

        [MatchParent("ACTYPE")]
        public string AccountType { get; set; } = string.Empty;
    }
}