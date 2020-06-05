using SolutionUtility;

namespace CIFAPI.Models
{
    public class CreateCifAddressResponseModel : BaseResponseModel
    {
        [MatchParent("CFCIFN")]
        public string CustomerNumber { get; set; }

        [MatchParent("CFADSQ")]
        public string AddressSequence { get; set; }
    }
}