using SolutionUtility;

namespace MBaseAPI.Models
{
    public class KycCIFLevelResponseModel : BaseResponseModel
    {
        public string CustomerNumber { get; set; }
        public string PreviousRiskLevel { get; set; }
        public string ReiskLevel { get; set; }
        public string LastReviewDate { get; set; }
        public string NextReviewDate { get; set; }
        public string PEPList { get; set; }
    }
}