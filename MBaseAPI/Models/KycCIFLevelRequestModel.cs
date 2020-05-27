using MBaseAccess.Entity;
using SolutionUtility;

namespace MBaseAPI.Models
{
    public class KycCIFLevelRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1708";

        [MatchParent("KCCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("KCOCPG")]
        public string BusinessGroupCode { get; set; }

        [MatchParent("KCCPRF")]
        public string CustomerProofFlag { get; set; }

        [MatchParent("KCIPRF")]
        public string IdentificationProofFlag { get; set; }

        [MatchParent("KCAPRF")]
        public string ProofOfAddressDocumentFlag { get; set; }

        [MatchParent("KCCOUN")]
        public string CustomerCountryCode { get; set; }

        [MatchParent("KCREPO")]
        public string PoliticalRelationship { get; set; }

        [MatchParent("KCSCOU")]
        public string CountrySourceOfFund { get; set; }

        [MatchParent("KCOTHR")]
        public string OtherInformation { get; set; }

        [MatchParent("KCASET")]
        public string EstimationIncomeValue { get; set; }

        [MatchParent("KCCPLX")]
        public string ComplexCompanyStructure { get; set; }

        [MatchParent("KCMTBA")]
        public string TBAMembership { get; set; }

        [MatchParent("KCTAX")]
        public string PayTax { get; set; }

        [MatchParent("KCRSET")]
        public string SETRegistration { get; set; }

        [MatchParent("KCOFFS")]
        public string OffshoreBusiness { get; set; }

        [MatchParent("KCICSH")]
        public string CashIncome { get; set; }

        [MatchParent("KCSDOC")]
        public string SufficientDocument { get; set; }

        [MatchParent("KCRTNF")]
        public string ReturnMailFlag { get; set; }

        [MatchParent("KCNPO")]
        public string NonProfitOrganization { get; set; }

        [MatchParent("CP9XST1")]
        public string XICSubType1 { get; set; }

        [MatchParent("CP9XCD1")]
        public string XICCode1 { get; set; }

        [MatchParent("CPXRMK1")]
        public string XICRemark1 { get; set; }

        [MatchParent("CP9XST2")]
        public string XICSubType2 { get; set; }

        [MatchParent("CP9XCD2")]
        public string XICCode2 { get; set; }

        [MatchParent("CPXRMK2")]
        public string XICRemark2 { get; set; }

        [MatchParent("CP9XST3")]
        public string XICSubType3 { get; set; }

        [MatchParent("CP9XCD3")]
        public string XICCode3 { get; set; }

        [MatchParent("CPXRMK3")]
        public string XICRemark3 { get; set; }

        [MatchParent("CP9XST4")]
        public string XICSubType4 { get; set; }

        [MatchParent("CP9XCD4")]
        public string XICCode4 { get; set; }

        [MatchParent("CPXRMK4")]
        public string XICRemark4 { get; set; }
    }
}