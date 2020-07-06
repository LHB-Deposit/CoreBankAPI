using SolutionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIFAPI.Models
{
    public class CreateCifAddresRequestModel : BaseRequestModel
    {
        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(4)]
        public string TranCode { get; set; } = "1721";

        [Required]
        [RegularExpression("^[0-9]*$")]
        [StringLength(19)]
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA2")]
        public string AddressLine1 { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA3")]
        public string AddressLine2 { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA4")]
        public string AddressLine3 { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA5")]
        public string AddressLine4 { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA6")]
        public string AddressLine5 { get; set; }

        [StringLength(40)]
        [MatchParent("CFNA7")]
        public string CityStateZip { get; set; }

        [Required]
        [StringLength(3)]
        [MatchParent("CFSTAT")]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        [MatchParent("WKZIP")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(3)]
        [MatchParent("CFCOUN")]
        public string Country { get; set; }

        [Required]
        [StringLength(1)]
        [MatchParent("CFADRT")]
        public string AddressType { get; set; }

        [StringLength(20)]
        [MatchParent("CFARMK")]
        public string AddressRemark { get; set; }

        [StringLength(1)]
        [MatchParent("CFADFM")]
        public string AddressFormat { get; set; }

        [StringLength(30)]
        [MatchParent("CFFHNO")]
        public string HouseNo { get; set; }

        [StringLength(10)]
        [MatchParent("CFFVNO")]
        public string VillageNo { get; set; }

        [StringLength(50)]
        [MatchParent("CFFBLD")]
        public string Building { get; set; }

        [StringLength(20)]
        public string Floor { get; set; }

        [StringLength(30)]
        public string Room { get; set; }

        [StringLength(50)]
        [MatchParent("CFFALY")]
        public string Alley { get; set; }

        [StringLength(50)]
        [MatchParent("CFFLAN")]
        public string Lane { get; set; }

        [StringLength(50)]
        [MatchParent("CFFRD")]
        public string Road { get; set; }

        [StringLength(50)]
        [MatchParent("CFFDIS")]
        public string SubDistrict { get; set; }

        [StringLength(50)]
        [MatchParent("CFFCIT")]
        public string District { get; set; }

        [StringLength(50)]
        [MatchParent("CFFST")]
        public string Province { get; set; }
    }
}