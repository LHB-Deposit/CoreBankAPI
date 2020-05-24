using SolutionUtility;

namespace MBaseAccess.Entity
{
    public class CIFAddress
    {
        [MatchParent("CustomerNumber")]
        public string CFCIFN { get; set; }

        [MatchParent("AddressLine1")]
        public string CFNA2 { get; set; }

        [MatchParent("AddressLine2")]
        public string CFNA3 { get; set; }

        [MatchParent("AddressLine3")]
        public string CFNA4 { get; set; }

        [MatchParent("AddressLine4")]
        public string CFNA5 { get; set; }

        [MatchParent("AddressLine5")]
        public string CFNA6 { get; set; }

        [MatchParent("CityStateZip")]
        public string CFNA7 { get; set; }

        [MatchParent("State")]
        public string CFSTAT { get; set; }

        [MatchParent("ZipCode")]
        public string WKZIP { get; set; }

        [MatchParent("Country")]
        public string CFCOUN { get; set; }

        [MatchParent("AddressType")]
        public string CFADRT { get; set; }

        [MatchParent("AddressRemark")]
        public string CFARMK { get; set; }

        [MatchParent("AddressFormat")]
        public string CFADFM { get; set; }

        [MatchParent("HouseNo")]
        public string CFFHNO { get; set; }

        [MatchParent("VillageNo")]
        public string CFFVNO { get; set; }

        [MatchParent("Building")]
        public string CFFBLD { get; set; }

        [MatchParent("Alley")]
        public string CFFALY { get; set; }

        [MatchParent("Lane")]
        public string CFFLAN { get; set; }

        [MatchParent("Road")]
        public string CFFRD { get; set; }

        [MatchParent("SubDistrict")]
        public string CFFDIS { get; set; }

        [MatchParent("District")]
        public string CFFCIT { get; set; }

        [MatchParent("Province")]
        public string CFFST { get; set; }
    }
}
