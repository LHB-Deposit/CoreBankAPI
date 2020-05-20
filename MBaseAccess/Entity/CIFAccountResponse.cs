using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class CIFAccountResponse : ResponseMessage
    {
        [MatchParent("CustumerNumber")]
        public string CFCIFN { get; set; }

        [MatchParent("AccountNumber")]
        public string CFACCTNO { get; set; }

        [MatchParent("AccountType")]
        public string CFACCTYP { get; set; }
    }
}
