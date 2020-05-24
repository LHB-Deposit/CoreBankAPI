using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class VerifyCitizen
    {
        [MatchParent("IDNumber")]
        public string CFSSNO { get; set; }

        [MatchParent("IDTypeCode")]
        public string CFSSCD { get; set; }

        [MatchParent("IDIssueCountryCode")]
        public string CFCIDT { get; set; }
    }
}
