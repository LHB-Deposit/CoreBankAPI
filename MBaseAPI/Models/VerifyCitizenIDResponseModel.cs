using MBaseAccess.Entity;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class VerifyCitizenIDResponseModel : ResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; } = string.Empty;

        [MatchParent("CFCIFT")]
        public string CustomerType { get; set; } = string.Empty;

        [MatchParent("CFNA1")]
        public string CustomerNameThai { get; set; } = string.Empty;

        [MatchParent("CFNA1A")]
        public string CustomerNameThai1 { get; set; } = string.Empty;

        [MatchParent("CFSSNO")]
        public string IDNumber { get; set; } = string.Empty;

        [MatchParent("CFSSCD")]
        public string IDTypeCode { get; set; } = string.Empty;

        [MatchParent("CFCIDT")]
        public string IDIssueCountryCode { get; set; } = string.Empty;

        [MatchParent("CFASN1")]
        public string CustomerNameEng { get; set; } = string.Empty;

        [MatchParent("CFASN2")]
        public string CustomerNameEng1 { get; set; } = string.Empty;

    }
}