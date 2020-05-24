using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFAddresRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1721";

        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("CFNA2")]
        public string AddressLine1 { get; set; }

        [MatchParent("CFNA3")]
        public string AddressLine2 { get; set; }

        [MatchParent("CFNA4")]
        public string AddressLine3 { get; set; }

        [MatchParent("CFNA5")]
        public string AddressLine4 { get; set; }

        [MatchParent("CFNA6")]
        public string AddressLine5 { get; set; }

        [MatchParent("CFNA7")]
        public string CityStateZip { get; set; }

        [MatchParent("CFSTAT")]
        public string State { get; set; }

        [MatchParent("WKZIP")]
        public string ZipCode { get; set; }

        [MatchParent("CFCOUN")]
        public string Country { get; set; }

        [MatchParent("CFADRT")]
        public string AddressType { get; set; }

        [MatchParent("CFARMK")]
        public string AddressRemark { get; set; }

        [MatchParent("CFADFM")]
        public string AddressFormat { get; set; }

        [MatchParent("CFFHNO")]
        public string HouseNo { get; set; }

        [MatchParent("CFFVNO")]
        public string VillageNo { get; set; }

        [MatchParent("CFFBLD")]
        public string Building { get; set; }

        [MatchParent("CFFALY")]
        public string Alley { get; set; }

        [MatchParent("CFFLAN")]
        public string Lane { get; set; }

        [MatchParent("CFFRD")]
        public string Road { get; set; }

        [MatchParent("CFFDIS")]
        public string SubDistrict { get; set; }

        [MatchParent("CFFCIT")]
        public string District { get; set; }

        [MatchParent("CFFST")]
        public string Province { get; set; }
    }
}