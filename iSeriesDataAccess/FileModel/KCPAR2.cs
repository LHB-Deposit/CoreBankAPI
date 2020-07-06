using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class KCPAR2
    {
        [MatchParent("BusinessOccupationGroupCode")]
        public string KCPBCD { get; set; }

        [MatchParent("BusinessOccupationGroupDescription1")]
        public string KCPBD1 { get; set; }

        [MatchParent("BusinessOccupationGroupDescription2")]
        public string KCPBD2 { get; set; }

        [MatchParent("ClassifiedRiskPower")]
        public string KCPBRP { get; set; }
    }
}
