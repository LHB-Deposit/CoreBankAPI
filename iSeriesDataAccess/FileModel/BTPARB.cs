using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class BTPARB
    {
        [MatchParent("CbankBusinessType")]
        public string BPBTYP { get; set; }

        [MatchParent("Description")]
        public string BPBDSC { get; set; }

        [MatchParent("HeaderFlag")]
        public string BPHFLG { get; set; }
    }
}
