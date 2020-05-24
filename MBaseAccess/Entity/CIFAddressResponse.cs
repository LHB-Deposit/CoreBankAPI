using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class CIFAddressResponse
    {
        [MatchParent("CustomerNumber")]
        public string CFCIFN { get; set; }

        [MatchParent("AddressSequence")]
        public string CFADSQ { get; set; }
    }
}
