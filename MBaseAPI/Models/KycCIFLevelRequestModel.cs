using MBaseAccess.Entity;
using SolutionUtility;
using System.ComponentModel.DataAnnotations;

namespace MBaseAPI.Models
{
    public class KycCIFLevelRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1708";

        [Required]
        [MaxLength(19)]
        [MatchParent("KCCIFN")]
        public string CustomerNumber { get; set; }

        [MaxLength(6)]
        [MatchParent("KCOCPG")]
        public string BusinessGroupCode { get; set; }

        [MaxLength(1)]
        [MatchParent("KCCPRF")]
        public string CustomerProofFlag { get; set; }

        [MaxLength(1)]
        [MatchParent("KCIPRF")]
        public string IdentificationProofFlag { get; set; }

        [MaxLength(1)]
        [MatchParent("KCAPRF")]
        public string ProofOfAddressDocumentFlag { get; set; }

        [MaxLength(3)]
        [MatchParent("KCCOUN")]
        public string CustomerCountryCode { get; set; }

        [MaxLength(40)]
        [MatchParent("KCREPO")]
        public string PoliticalRelationship { get; set; }

        [MaxLength(3)]
        [MatchParent("KCSCOU")]
        public string CountrySourceOfFund { get; set; }

        [MaxLength(40)]
        [MatchParent("KCOTHR")]
        public string OtherInformation { get; set; }

        [MaxLength(17)]
        [MatchParent("KCASET")]
        public string EstimationIncomeValue { get; set; }

        [MaxLength(1)]
        [MatchParent("KCCPLX")]
        public string ComplexCompanyStructure { get; set; }

        [MaxLength(1)]
        [MatchParent("KCMTBA")]
        public string TBAMembership { get; set; }

        [MaxLength(1)]
        [MatchParent("KCTAX")]
        public string PayTax { get; set; }

        [MaxLength(1)]
        [MatchParent("KCRSET")]
        public string SETRegistration { get; set; }

        [MaxLength(1)]
        [MatchParent("KCOFFS")]
        public string OffshoreBusiness { get; set; }

        [MaxLength(1)]
        [MatchParent("KCICSH")]
        public string CashIncome { get; set; }

        [MaxLength(1)]
        [MatchParent("KCSDOC")]
        public string SufficientDocument { get; set; }

        [MaxLength(1)]
        [MatchParent("KCRTNF")]
        public string ReturnMailFlag { get; set; }

        [MaxLength(1)]
        [MatchParent("KCNPO")]
        public string NonProfitOrganization { get; set; }

        [MaxLength(10)]
        [MatchParent("CP9XST1")]
        public string XICSubType1 { get; set; }

        [MaxLength(2)]
        [MatchParent("CP9XCD1")]
        public string XICCode1 { get; set; }

        [MaxLength(40)]
        [MatchParent("CPXRMK1")]
        public string XICRemark1 { get; set; }

        [MaxLength(10)]
        [MatchParent("CP9XST2")]
        public string XICSubType2 { get; set; }

        [MaxLength(2)]
        [MatchParent("CP9XCD2")]
        public string XICCode2 { get; set; }

        [MaxLength(40)]
        [MatchParent("CPXRMK2")]
        public string XICRemark2 { get; set; }

        [MaxLength(10)]
        [MatchParent("CP9XST3")]
        public string XICSubType3 { get; set; }

        [MaxLength(2)]
        [MatchParent("CP9XCD3")]
        public string XICCode3 { get; set; }

        [MaxLength(40)]
        [MatchParent("CPXRMK3")]
        public string XICRemark3 { get; set; }

        [MaxLength(10)]
        [MatchParent("CP9XST4")]
        public string XICSubType4 { get; set; }

        [MaxLength(2)]
        [MatchParent("CP9XCD4")]
        public string XICCode4 { get; set; }

        [MaxLength(40)]
        [MatchParent("CPXRMK4")]
        public string XICRemark4 { get; set; }
    }
}