using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class DPI2195FP
    {
        [MatchParent("FatcaCode")]
        public string FPCOD { get; set; }

        [MatchParent("FatcaDescription")]
        public string FPDESC { get; set; }

        [MatchParent("FatcaDescription2")]
        public string FPDESC2 { get; set; }
    }
}
