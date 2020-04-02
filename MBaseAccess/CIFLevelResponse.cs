using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess
{
    public class CIFLevelResponse
    {
        public string CustomerNumber { get; set; }
        public string PreviousRiskLevel { get; set; }
        public string ReiskLevel { get; set; }
        public string LastReviewDate { get; set; }
        public string NextReviewDate { get; set; }
        public string PEPList { get; set; }
    }
}
