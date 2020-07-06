using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFZPAR
    {
        [MatchParent("AddressType")]
        public string CFZADT { get; set; }

        [MatchParent("Description")]
        public string CFZDSC { get; set; }

        [MatchParent("Text")]
        public string CFZTXT { get; set; }

        [MatchParent("ValueType")]
        public string CFZVTY { get; set; }
    }
}
