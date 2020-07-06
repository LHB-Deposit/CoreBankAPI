using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFPAR3
    {
        [MatchParent("RecordStatus")]
        public string CP3RID { get; set; }

        [MatchParent("UICNumber")]
        public string CP3UIC { get; set; }

        [MatchParent("UICDescription")]
        public string CP3UID { get; set; }

        [MatchParent("UserCode")]
        public string CP3UCD { get; set; }

        [MatchParent("UserDescription")]
        public string CP3DSC { get; set; }
    }
}
