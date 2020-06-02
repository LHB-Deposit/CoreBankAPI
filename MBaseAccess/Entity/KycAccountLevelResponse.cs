using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class KycAccountLevelResponse : ResponseMessage
    {
        [MatchParent("AccountType")]
        public string KCATYP { get; set; }

        [MatchParent("AccountNumber")]
        public string KCACCN { get; set; }

        [MatchParent("PurposeOfOpenAccount")]
        public string DEPPURINV { get; set; }

        [MatchParent("SourceOfFund")]
        public string DEPSRCINV { get; set; }

        [MatchParent("SourceCountryOfFund")]
        public string KCSCOU { get; set; }

        [MatchParent("OpenAmount")]
        public string KCOPAM { get; set; }
    }
}
