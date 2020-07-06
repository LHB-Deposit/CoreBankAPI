using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class CFZPEL
    {
        [MatchParent("EducationLevel")]
        public string CFZEDL { get; set; }

        [MatchParent("Description")]
        public string CFZEDD { get; set; }
    }
}
