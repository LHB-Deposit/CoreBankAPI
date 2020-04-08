using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class VerifyCitizenIDNumberResponse
    {
        public string CustomerNumber { get; set; } = string.Empty;
        public string CustomerType { get; set; } = string.Empty;
        public string CustomerNameThai { get; set; } = string.Empty;
        public string CustomerNameThai1 { get; set; } = string.Empty;
        public string IDNumber { get; set; } = string.Empty;
        public string IDTypeCode { get; set; } = string.Empty;
        public string IDIssueCountryCode { get; set; } = string.Empty;
        public string CustomerNameEng { get; set; } = string.Empty;
        public string CustomerNameEng1 { get; set; } = string.Empty;

    }
}