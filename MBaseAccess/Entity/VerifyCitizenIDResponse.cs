using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class VerifyCitizenIDResponse
    {
        [MatchParent("CustomerNumber")]
        public string CFCIFN { get; set; }

        [MatchParent("CustomerType")]
        public string CFCIFT { get; set; }

        [MatchParent("CustomerNameTh")]
        public string CFNA1 { get; set; }

        [MatchParent("CustomerNameTh1")]
        public string CFNA1A { get; set; }

        [MatchParent("IDNumber")]
        public string CFSSNO { get; set; }

        [MatchParent("IDTypeCode")]
        public string CFSSCD { get; set; }

        [MatchParent("IDIssueCountryCode")]
        public string CFCIDT { get; set; }

        [MatchParent("CustomerNameEn")]
        public string CFNAE { get; set; }

        //[MatchParent("CustomerNameEn1")]
        //public string CFNAEA { get; set; } // TODO Fix Field Name: CFCNA1A
    }
}
