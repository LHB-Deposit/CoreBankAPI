using SolutionUtility;

namespace KYCAPI.Helpers
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
        
        // File
        public string KCMAST { get; set; }
    }
}