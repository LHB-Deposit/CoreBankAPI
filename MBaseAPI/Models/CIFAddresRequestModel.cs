using SolutionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFAddresRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1721";

        [Required]
        [MaxLength(19)]
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA2")]
        public string AddressLine1 { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA3")]
        public string AddressLine2 { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA4")]
        public string AddressLine3 { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA5")]
        public string AddressLine4 { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA6")]
        public string AddressLine5 { get; set; }

        [MaxLength(40)]
        [MatchParent("CFNA7")]
        public string CityStateZip { get; set; }

        [Required]
        [MaxLength(3)]
        [MatchParent("CFSTAT")]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        [MatchParent("WKZIP")]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(3)]
        [MatchParent("CFCOUN")]
        public string Country { get; set; }

        [Required]
        [MaxLength(1)]
        [MatchParent("CFADRT")]
        public string AddressType { get; set; }

        [MaxLength(20)]
        [MatchParent("CFARMK")]
        public string AddressRemark { get; set; }

        [MaxLength(1)]
        [MatchParent("CFADFM")]
        public string AddressFormat { get; set; }

        [MaxLength(30)]
        [MatchParent("CFFHNO")]
        public string HouseNo { get; set; }

        [MaxLength(10)]
        [MatchParent("CFFVNO")]
        public string VillageNo { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFBLD")]
        public string Building { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFALY")]
        public string Alley { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFLAN")]
        public string Lane { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFRD")]
        public string Road { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFDIS")]
        public string SubDistrict { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFCIT")]
        public string District { get; set; }

        [MaxLength(50)]
        [MatchParent("CFFST")]
        public string Province { get; set; }
    }
}