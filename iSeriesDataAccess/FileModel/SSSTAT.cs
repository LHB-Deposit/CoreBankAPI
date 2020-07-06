using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class SSSTAT
    {
        [MatchParent("CountryCode")]
        public string SSSCOC { get; set; }

        [MatchParent("StateCode")]
        public string SSSTAC { get; set; }

        [MatchParent("StateName")]
        public string SSSTAN { get; set; }

        [MatchParent("StateSubDivision")]
        public string SSSSUB { get; set; }

        [MatchParent("WHRate")]
        public string SSSWRT { get; set; }

        [MatchParent("RebateMethod")]
        public string SSSREB { get; set; }

        [MatchParent("RevolvingCreditMethod")]
        public string SSSRVC { get; set; }

        [MatchParent("StateText")]
        public string SSSTXT { get; set; }
    }
}
