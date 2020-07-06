using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFPARE
    {
        [MatchParent("FormatCode")]
        public string CFTTCD { get; set; }

        [MatchParent("SubTypeCode")]
        public string CFTTTP { get; set; }

        [MatchParent("TitleDescription")]
        public string CFTTDS { get; set; }
    }
}
