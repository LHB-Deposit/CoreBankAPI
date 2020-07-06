using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class SSCOUN
    {
        [MatchParent("CountryCode")]
        public string SSCCOC { get; set; }

        [MatchParent("CountryName")]
        public string SSCNAM { get; set; }

        [MatchParent("CountrySubdivision")]
        public string SSCSUB { get; set; }

        [MatchParent("CountryText")]
        public string SSCTXT { get; set; }

        [MatchParent("StdEnrouteRemittance")]
        public string SSCREM { get; set; }

        [MatchParent("CountryAddressFormat")]
        public string SSCAFM { get; set; }
    }
}
