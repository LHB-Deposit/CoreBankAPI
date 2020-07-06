using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class KCPAR3
    {
        [MatchParent("Country")]
        public string KCPCOC { get; set; }

        [MatchParent("CountryRiskGroup")]
        public string KCPCRG { get; set; }

        [MatchParent("CountryRiskPower")]
        public string KCPCRP { get; set; }

        [MatchParent("NationalityRiskFlag")]
        public string KCPCNR { get; set; }
    }
}
