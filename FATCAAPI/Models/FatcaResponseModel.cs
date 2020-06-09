using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATCAAPI.Models
{
    public class FatcaResponseModel : BaseRequestModel
    {
        public string CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public string YorN { get; set; }
        public string FATCACode { get; set; }
    }
}