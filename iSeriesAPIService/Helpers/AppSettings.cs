using iSeriesDataAccess;

namespace iSeriesAPIService.Helpers
{
    public class AppSettings : ProjectAppSettings
    {
        public string LHBDDATPAR { get; set; }
        public string LHBDDATMAS { get; set; }
        public string LHBPDATPAR { get; set; }
        public string LHBPDATMAS { get; set; }

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
    }
}