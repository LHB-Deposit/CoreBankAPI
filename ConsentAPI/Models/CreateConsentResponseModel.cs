using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsentAPI.Models
{
    public class CreateConsentResponseModel : BaseResponseModel
    {
        public string CustomerNumber { get; set; }
        public string DocumentType { get; set; }
        public string DocumentCode { get; set; }
        public string ConsentFlag { get; set; }
        public string CreateDate { get; set; }
    }
}