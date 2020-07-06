using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFSICC
    {
        [MatchParent("BusinessType")]
        public string CFBUST { get; set; }

        [MatchParent("StandardIndustryName")]
        public string CFSINA { get; set; }
    }
}
