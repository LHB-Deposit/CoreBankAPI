using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFIDDF
    {
        [MatchParent("IDNumberCode")]
        public string CFIDCD { get; set; }

        [MatchParent("IDNumberRequired")]
        public string CFIDRQ { get; set; }

        [MatchParent("IDNumberType")]
        public string CFIDTY { get; set; }

        [MatchParent("IDNumberSize")]
        public string CFIDSZ { get; set; }

        [MatchParent("IDNumberModulusProgram")]
        public string CFIDMO { get; set; }

        [MatchParent("IDNumberEditWord")]
        public string CFIDED { get; set; }

        [MatchParent("DaysUntilException")]
        public string CFIDEX { get; set; }

        [MatchParent("ExceptionDescription")]
        public string CFIDET { get; set; }

        [MatchParent("IDNumberDescription")]
        public string CFIDSC { get; set; }
    }
}
