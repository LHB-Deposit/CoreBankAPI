using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class CIFDetailInquiryResponse
    {
        [MatchParent("CustomerNumber")]
        public string CFCIFN { get; set; }

        [MatchParent("CustomerType")]
        public string CFCIFT { get; set; }

        [MatchParent("BankNumber")]
        public string CFBNKN { get; set; }

        [MatchParent("BranchNumber")]
        public string CFBRNN { get; set; }

        [MatchParent("CostCenter")]
        public string CFCOST { get; set; }

        [MatchParent("CustomerName")]
        public string CFNA1 { get; set; }

        [MatchParent("CustomerName1")] // TODO Fix name
        public string CFNA1A { get; set; }

        [MatchParent("IDNumber")]
        public string CFSSNO { get; set; }

        [MatchParent("IDTypeCode")]
        public string CFSSCD { get; set; }

        [MatchParent("IDIssueCountryCode")]
        public string CFCIDT { get; set; }

        [MatchParent("DateOfBirth")]
        public string CFBIR8 { get; set; }

        [MatchParent("Individual")]
        public string CFINDI { get; set; }

        [MatchParent("CIFGroupCode")]
        public string CFGRUP { get; set; }

        [MatchParent("Gender")]
        public string CFSEX { get; set; }

        [MatchParent("InquiryCode")]
        public string CFINQC { get; set; }

        [MatchParent("OfficerCode")]
        public string CFOFFR { get; set; }

        [MatchParent("EmployerName")]
        public string CFEMPL { get; set; }

        [MatchParent("InsiderCode")]
        public string CFINSC { get; set; }

        [MatchParent("VIPCustomer")]
        public string CFVIPC { get; set; }

        [MatchParent("DeceasedCustomerFlag")]
        public string CFDEAD { get; set; }

        [MatchParent("InsufficientAddress")]
        public string CFBADA { get; set; }

        [MatchParent("HoldMailCode")]
        public string CFHLDM { get; set; }

        [MatchParent("Phone1")]
        public string CFHPHO { get; set; }

        [MatchParent("Phone2")]
        public string CFBPHO { get; set; }

        [MatchParent("Phone3")]
        public string CFBFHO { get; set; }

        [MatchParent("ProfitAnalysis")]
        public string CFPROA { get; set; }

        [MatchParent("SICN1UserDefined")]
        public string CFSIC1 { get; set; }

        [MatchParent("SICN2UserDefined")]
        public string CFSIC2 { get; set; }

        [MatchParent("SICN3UserDefined")]
        public string CFSIC3 { get; set; }

        [MatchParent("SICN4UserDefined")]
        public string CFSIC4 { get; set; }

        [MatchParent("SICN5UserDefined")]
        public string CFSIC5 { get; set; }

        [MatchParent("SICN6UserDefined")]
        public string CFSIC6 { get; set; }

        [MatchParent("SICN7UserDefined")]
        public string CFSIC7 { get; set; }

        [MatchParent("SICN8UserDefined")]
        public string CFSIC8 { get; set; }

        [MatchParent("ResidentCode")]
        public string CFRESD { get; set; }

        [MatchParent("Country")]
        public string CFCNTY { get; set; }

        [MatchParent("CountryOfCitizenship")]
        public string CFCITZ { get; set; }

        [MatchParent("CountryOfHeritage")]
        public string CFRACE { get; set; }

        [MatchParent("NameFormat")]
        public string CFMNIN { get; set; }

        [MatchParent("SMSACode")]
        public string CFSMSA { get; set; }

        [MatchParent("OccupationCode")]
        public string CFBUST { get; set; }

        [MatchParent("SubClass")]
        public string CFSCLA { get; set; }

        [MatchParent("CustomerRating")]
        public string CFCRAT { get; set; }

        [MatchParent("CIFCombinedCycle")]
        public string CFCCYC { get; set; }

        [MatchParent("TINStatus")]
        public string CFTINS { get; set; }

        [MatchParent("FedWHCode")]
        public string CFWHCD { get; set; }

        [MatchParent("StateWHCode")]
        public string CFWHPR { get; set; }

        [MatchParent("FederalWithHoldingDate")]
        public string CFWHD6 { get; set; }

        [MatchParent("UICN1UserDefined")]
        public string CFUIC1 { get; set; }

        [MatchParent("UICN2UserDefined")]
        public string CFUIC2 { get; set; }

        [MatchParent("UICN3UserDefined")]
        public string CFUIC3 { get; set; }

        [MatchParent("UICN4UserDefined")]
        public string CFUIC4 { get; set; }

        [MatchParent("UICN5UserDefined")]
        public string CFUIC5 { get; set; }

        [MatchParent("UICN6UserDefined")]
        public string CFUIC6 { get; set; }

        [MatchParent("UICN7UserDefined")]
        public string CFUIC7 { get; set; }

        [MatchParent("UICN8UserDefined")]
        public string CFUIC8 { get; set; }

        [MatchParent("LanguageIdentfier")]
        public string CFLGID { get; set; }

        [MatchParent("CustomerType")]
        public string BTCTYP { get; set; }

        [MatchParent("MajorBusinessType")]
        public string BTMBTY { get; set; }

        [MatchParent("AddressSequence")]
        public string CFADSQ { get; set; }

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

        [MatchParent("ZIPCode")]
        public string WKZIP { get; set; }

        [MatchParent("Country1")]
        public string CFCOUN { get; set; } // TODO Fix Name

        [MatchParent("AddressType")]
        public string CFADRT { get; set; }

        [MatchParent("AddressRemark")]
        public string CFARMK { get; set; }

        [MatchParent("AddressFormat")]
        public string CFADFM { get; set; }
    }
}
