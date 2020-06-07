using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class DPI2142F1
    {
        [MatchParent("CustomerNumber")]
        public string F1CIF { get; set; }

        [MatchParent("DocumentType")]
        public string F1TYP { get; set; }

        [MatchParent("DocumentCode")]
        public string F1COD { get; set; }

        [MatchParent("ConsentFlag")]
        public string F1STS { get; set; }

        [MatchParent("Remark")]
        public string F1REMRK { get; set; }

        [MatchParent("CreateBranch")]
        public string F1CTBRN { get; set; }

        [MatchParent("CreateDate6")]
        public string F1CTDT6 { get; set; }

        [MatchParent("CreateDate7")]
        public string F1CTDT7 { get; set; }

        [MatchParent("LastUpdateBranch")]
        public string F1UPBRN { get; set; }

        [MatchParent("LastUpdateDate6")]
        public string F1UPDT6 { get; set; }

        [MatchParent("LastUpdateDate7")]
        public string F1UPDT7 { get; set; }

        [MatchParent("LastUser")]
        public string F1UPUSR { get; set; }
    }
}
