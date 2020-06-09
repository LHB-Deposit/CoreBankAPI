using SolutionUtility;

namespace MBaseAPI.Models
{
    public class ResponseModel
    {
        [MatchParent("ErrorCode")]
        public string ErrorCode { get; set; }

        [MatchParent("ErrorDescription")]
        public string ErrorDescription { get; set; }
    }
}