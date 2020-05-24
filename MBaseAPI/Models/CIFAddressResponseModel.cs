using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFAddressResponseModel : ResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("CFADSQ")]
        public string AddressSequence { get; set; }
    }
}