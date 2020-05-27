using MBaseAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBaseAPI.Models
{
    public class CIFCreateRequestModel : RequestModel
    {
        public string TranCode { get; set; } = "1732";

        [MaxLength(40)]
        public string TitleThaiName { get; set; } = string.Empty;

        [Required]
        [MaxLength(40)]
        public string ThaiName { get; set; }

        [Required]
        [MaxLength(40)]
        public string ThaiSurename { get; set; }

        [MaxLength(40)]
        public string TitleEngName { get; set; } = string.Empty;

        [Required]
        [MaxLength(40)]
        public string EngName { get; set; }

        [Required]
        [MaxLength(40)]
        public string EngSurename { get; set; }

        [Required]
        [MaxLength(15)]
        public string IDNumber { get; set; }

        [Required]
        [MaxLength(2)]
        public string IDTypeCode { get; set; }

        [Required]
        [MaxLength(3)]
        public string IDIssueCountryCode { get; set; }

        [Required]
        [MaxLength(6)]
        public string CustomerType { get; set; }

        [Required]
        [MaxLength(8)]
        public string MajorBusinessType { get; set; }

        [Required]
        [MaxLength(3)]
        public string CostCenter { get; set; }

        [MaxLength(3)]
        public string OfficerCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(8)]
        public string BirthDate { get; set; }

        [Required]
        [MaxLength(1)]
        public string ResidentCode { get; set; }

        [Required]
        [MaxLength(3)]
        public string Country { get; set; } = "TH";

        [Required]
        [MaxLength(3)]
        public string CountryOfCitizenship { get; set; }

        [Required]
        [MaxLength(3)]
        public string CountryOfHeritage { get; set; }

        [MaxLength(15)]
        public string InquiryCode { get; set; } = string.Empty;

        [MaxLength(40)]
        public string EmployerName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string HomePhone { get; set; } = string.Empty;

        [MaxLength(20)]
        public string OfficePhone { get; set; } = string.Empty;

        [MaxLength(20)]
        public string OtherPhone { get; set; } = string.Empty;

        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }

        [MaxLength(10)]
        public string SMSACode { get; set; } = string.Empty;

        [Required]
        [MaxLength(4)]
        public string Occupation { get; set; }

        [MaxLength(1)]
        public string SubClass { get; set; } = string.Empty;

        [MaxLength(3)]
        public string CustomerRating { get; set; } = string.Empty;

        [MaxLength(1)]
        public string CIFGroupCode { get; set; } = string.Empty;

        [MaxLength(2)]
        public string CIFCombinedCycle { get; set; } = string.Empty;

        [MaxLength(1)]
        public string TINStatus { get; set; } = string.Empty;

        [MaxLength(1)]
        public string FedWHCode { get; set; } = string.Empty;

        [MaxLength(1)]
        public string StateWHCode { get; set; } = string.Empty;

        [MaxLength(1)]
        public string InsiderCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(1)]
        public string VIPCustomer { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string DeceasedCutomerFlag { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string InsufficientAddress { get; set; } = "N";

        [MaxLength(1)]
        public string HoldMailCode { get; set; } = string.Empty;

        [MaxLength(6)]
        public string CustomerReviewDate { get; set; } = "0";

        [Required]
        [MaxLength(1)]
        public string SICN1UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN2UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN3UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN4UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN5UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN6UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN7UserDefined { get; set; } = "N";

        [Required]
        [MaxLength(1)]
        public string SICN8UserDefined { get; set; } = "N";

        [MaxLength(1)]
        public string UICN1UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN2UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN3UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN4UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN5UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN6UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN7UserDefined { get; set; } = string.Empty;

        [MaxLength(1)]
        public string UICN8UserDefined { get; set; } = string.Empty;

        [MaxLength(3)]
        public string LanguageIdentifier { get; set; } = string.Empty;

        [Required]
        [MaxLength(1)]
        public string Retention { get; set; } = "9";

        [Required]
        [MaxLength(2)]
        public string DepositTypeCode { get; set; }

        [Required]
        [MaxLength(1)]
        public string AccountType { get; set; }

        [Required]
        [MaxLength(1)]
        public string SourceOfFunds { get; set; }

        [Required]
        [MaxLength(1)]
        public string CreateAccountFlag { get; set; }

        [MaxLength(40)]
        public string EmployerName01 { get; set; } = string.Empty; // *

        [MaxLength(3)]
        public string IncomeCapitalAmount { get; set; } = string.Empty;

        [MaxLength(8)]
        public string CompanyBusinessType { get; set; } = string.Empty;

        [MaxLength(1)]
        public string EducationLevel { get; set; } = string.Empty;

        [MaxLength(30)]
        public string ElectronicAddress { get; set; } = string.Empty;

    }
}