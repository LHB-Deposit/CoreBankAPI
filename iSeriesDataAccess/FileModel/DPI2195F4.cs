using SolutionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class DPI2195F4
    {
        [MatchParent("ReferenceKey")]
        [StringLength(30)]
        public string F4REFKEY { get; set; }

        [MatchParent("Status")]
        [StringLength(1)]
        public string F4STS { get; set; }

        [MatchParent("TransectionType")]
        [StringLength(3)]
        public string F4TYP { get; set; }

        [MatchParent("StatusDescription")]
        [StringLength(60)]
        public string F4STDESC { get; set; }

        [MatchParent("TransectionText")]
        [StringLength(500)]
        public string F4TEXT { get; set; }

        [MatchParent("Date8")]
        [StringLength(8)]
        public string F4DAT8 { get; set; }

        [MatchParent("Time")]
        [StringLength(6)]
        public string F4TIME { get; set; }
    }
}
