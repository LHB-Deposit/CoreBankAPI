using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public sealed class CIFAccount
    {
        [MatchParent("TitleThaiName")]
        public string TCFTTIT { get; set; }

        [MatchParent("ThaiName")]
        public string TCFNA1 { get; set; }

        [MatchParent("ThaiSurename")]
        public string TCFNA1A { get; set; }

        [MatchParent("TitleEngName")]
        public string TCFETIT { get; set; }

        [MatchParent("EngName")]
        public string TCFASN1 { get; set; }

        [MatchParent("EngSurename")]
        public string TCFASN2 { get; set; }

        [MatchParent("IDNumber")]
        public string CFSSNO { get; set; }

        [MatchParent("IDTypeCode")]
        public string CFSSCD { get; set; }

        [MatchParent("IDIssueCountryCode")]
        public string CFCIDT { get; set; }

        [MatchParent("CustomerType")]
        public string BTCTYP { get; set; }

        [MatchParent("MajorBusinessType")]
        public string BTMBTY { get; set; }

        [MatchParent("BranchNumber")]
        public string CFBRNN { get; set; }

        [MatchParent("CostCenter")]
        public string CFCOST { get; set; }

        [MatchParent("OfficerCode")]
        public string CFOFFR { get; set; }

        [MatchParent("BirthDate")]
        public string CFBIR8 { get; set; }

        [MatchParent("ResidentCode")]
        public string CFRESD { get; set; }

        [MatchParent("Country")]
        public string CFCNTY { get; set; }

        [MatchParent("CountryOfCitzenship")]
        public string CFCITZ { get; set; }

        [MatchParent("CountryOfHeritage")]
        public string CFRACE { get; set; }

        [MatchParent("InquieryCode")]
        public string CFINQC { get; set; }

        [MatchParent("EmployerName")]
        public string CFEMPL { get; set; }

        [MatchParent("HomePhone")]
        public string CFHPHO { get; set; }

        [MatchParent("OfficePhone")]
        public string CFBPHO { get; set; }

        [MatchParent("OtherPhone")]
        public string CFBFHO { get; set; }

        [MatchParent("Gender")]
        public string CFSEX { get; set; }

        [MatchParent("SMSACode")]
        public string CFSMSA { get; set; }

        [MatchParent("Occupation")]
        public string CFBUST { get; set; }

        [MatchParent("SubClass")]
        public string CFSCLA { get; set; }

        [MatchParent("CustomerRating")]
        public string CFCRAT { get; set; }

        [MatchParent("CIFGroupCode")]
        public string CFGRUP { get; set; }

        [MatchParent("CIFCombinedCycle")]
        public string CFCCYC { get; set; }

        [MatchParent("TINStatus")]
        public string CFTINS { get; set; }

        [MatchParent("FedWHCode")]
        public string CFWHCD { get; set; }

        [MatchParent("StateWHCode")]
        public string CFWHPR { get; set; }

        [MatchParent("InsiderCode")]
        public string CFINSC { get; set; }

        [MatchParent("VIPCustomer")]
        public string CFVIPC { get; set; }

        [MatchParent("DeceasedCustomerFlag")]
        public string CFDEAD { get; set; }

        [MatchParent("InsufficientAddress")]
        public string CFBADA { get; set; }

        [MatchParent("HoleMailCode")]
        public string CFHLDM { get; set; }

        [MatchParent("CustomerReviewDate")]
        public string CFFSD6 { get; set; }

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

        [MatchParent("LanguageIdentifier")]
        public string CFLGID { get; set; }

        [MatchParent("Retention")]
        public string CFRETN { get; set; }

        [MatchParent("DepositTypeCode")]
        public string SSCODE { get; set; }

        [MatchParent("AccountType")]
        public string ACTYPE { get; set; }

        [MatchParent("EmployerName01")]
        public string CFENA1 { get; set; }  // Name Already CFEMPL

        [MatchParent("IncomeCapitalAmount")]
        public string CBINCC { get; set; }

        [MatchParent("CompanyBusinessType")]
        public string CFZTYP { get; set; }

        [MatchParent("EducationLevel")]
        public string CFEDLV { get; set; }

        [MatchParent("ElectronicAddress")]
        public string CFEADD { get; set; }
    }
}
