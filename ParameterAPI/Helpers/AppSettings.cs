using SolutionUtility;

namespace ParameterAPI.Helpers
{
    public class AppSettings : ProjectAppSettings
    {
        // Library
        public string LHBDDATPAR { get; set; }
        public string LHBDDATMAS { get; set; }
        public string LHBPDATPAR { get; set; }
        public string LHBPDATMAS { get; set; }
        public string LHBTDATINH { get; set; }
        public string LHBPDATINH { get; set; }

        // File, Key, Value
        public string BOTOccuKey { get; set; }
        public string BOTOccuValue { get; set; }
        public string BOTOccuFile { get; set; }

        public string BusinessTypeKey { get; set; }
        public string BusinessTypeValue { get; set; }
        public string BusinessTypeFile { get; set; }

        public string DocTypeKey { get; set; }
        public string DocTypeValue { get; set; }
        public string DocTypeFile { get; set; }

        public string EduLevelKey { get; set; }
        public string EduLevelValue { get; set; }
        public string EduLevelFile { get; set; }

        public string OccRiskKey { get; set; }
        public string OccRiskValue { get; set; }
        public string OccRiskFile { get; set; }

        public string PrefixNameKey { get; set; }
        public string PrefixNameValue { get; set; }
        public string PrefixNameFile { get; set; }

        public string StatusKey { get; set; }
        public string StatusValue { get; set; }
        public string StatusFile { get; set; }

        public string AccountTypeKey { get; set; }
        public string AccountTypeValue { get; set; }
        public string AccountTypeFile { get; set; }

        public string CountryKey { get; set; }
        public string CountryValue { get; set; }
        public string CountryFile { get; set; }

        public string KYCParameterKey { get; set; }
        public string KYCParameterValue { get; set; }
        public string KYCParameterFile { get; set; }

        public string OccupationKey { get; set; }
        public string OccupationValue { get; set; }
        public string OccupationFile { get; set; }

        public string StateOfThailandKey { get; set; }
        public string StateOfThailandValue { get; set; }
        public string StateOfThailandFile { get; set; }

        public string AddressTypeKey { get; set; }
        public string AddressTypeValue { get; set; }
        public string AddressTypeFile { get; set; }

        public string FatcaDescriptionKey { get; set; }
        public string FatcaDescriptionTHValue { get; set; }
        public string FatcaDescriptionENValue { get; set; }
        public string FatcaDescriptionFile { get; set; }
    }
}