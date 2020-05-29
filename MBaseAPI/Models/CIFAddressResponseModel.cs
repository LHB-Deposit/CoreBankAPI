using SolutionUtility;

namespace MBaseAPI.Models
{
    public class CIFAddressResponseModel : BaseResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("CFADSQ")]
        public string AddressSequence { get; set; }
    }
}