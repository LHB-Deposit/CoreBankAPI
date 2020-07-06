using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFPAR9
    {
        [MatchParent("Application")]
        public string CP9XIA { get; set; }

        [MatchParent("XICType")]
        public string CP9XIT { get; set; }

        [MatchParent("XICSubType")]
        public string CP9XST { get; set; }

        [MatchParent("XICDescription")]
        public string CP9XID { get; set; }

        [MatchParent("ValueType")]
        public string CP9VTY { get; set; }

        [MatchParent("UserCode")]
        public string CP9XCD { get; set; }

        [MatchParent("UserDescription")]
        public string CP9DSC { get; set; }

        [MatchParent("RemarkFlag")]
        public string CP9XRM { get; set; }
    }
}
