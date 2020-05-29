using SolutionUtility;

namespace MBaseAPI.Models
{
    public class CIFCreateResponseModel : BaseResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; } = string.Empty;

        [MatchParent("CFACCTNO")]
        public string AccountNumber { get; set; } = string.Empty;

        [MatchParent("CFACCTYP")]
        public string AccountType { get; set; } = string.Empty;
    }
}