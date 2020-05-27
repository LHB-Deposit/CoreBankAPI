using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class KycCIFLevel
    {
        [MatchParent("CustomerNumber")]
        public string KCCIFN { get; set; }

        [MatchParent("BusinessOccupationGroupCode")]
        public string KCOCPG { get; set; }

        [MatchParent("CustomerProofFlag")]
        public string KCCPRF { get; set; }

        [MatchParent("IdentificationProofFlag")]
        public string KCIPRF { get; set; }

        [MatchParent("ProofOfAddressDocumentFlag")]
        public string KCAPRF { get; set; }

        [MatchParent("CustomerCountryCode")]
        public string KCCOUN { get; set; }

        [MatchParent("PoliticalRelationship")]
        public string KCREPO { get; set; }

        [MatchParent("CountrySourceOfFund")]
        public string KCSCOU { get; set; }

        [MatchParent("OthersInformation")]
        public string KCOTHR { get; set; }

        [MatchParent("EstimationIncomeValue")]
        public string KCASET { get; set; }

        [MatchParent("ComplexCompanyStructure")]
        public string KCCPLX { get; set; }

        [MatchParent("TBAMembership")]
        public string KCMTBA { get; set; }

        [MatchParent("PayTax")]
        public string KCTAX { get; set; }

        [MatchParent("SETRegistration")]
        public string KCRSET { get; set; }

        [MatchParent("OffshoreBusiness")]
        public string KCOFFS { get; set; }

        [MatchParent("CashIncome")]
        public string KCICSH { get; set; }

        [MatchParent("SufficientDocument")]
        public string KCSDOC { get; set; }

        [MatchParent("ReturnMailFlag")]
        public string KCRTNF { get; set; }

        [MatchParent("NonProfitOrganization")]
        public string KCNPO { get; set; }

        [MatchParent("XICSubType1")]
        public string CP9XST1 { get; set; }

        [MatchParent("XICCode1")]
        public string CP9XCD1 { get; set; }

        [MatchParent("XICRemark1")]
        public string CPXRMK1 { get; set; }

        [MatchParent("XICSubType2")]
        public string CP9XST2 { get; set; }

        [MatchParent("XICCode2")]
        public string CP9XCD2 { get; set; }

        [MatchParent("XICRemark2")]
        public string CPXRMK2 { get; set; }

        [MatchParent("XICSubType3")]
        public string CP9XST3 { get; set; }

        [MatchParent("XICCode3")]
        public string CP9XCD3 { get; set; }

        [MatchParent("XICRemark3")]
        public string CPXRMK3 { get; set; }

        [MatchParent("XICSubType4")]
        public string CP9XST4 { get; set; }

        [MatchParent("XICCode4")]
        public string CP9XCD4 { get; set; }

        [MatchParent("XICRemark4")]
        public string CPXRMK4 { get; set; }

    }
}
