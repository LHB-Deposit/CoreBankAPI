using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSeriesDataAccess.FileModel
{
    public class DPI2392F
    {
        [MatchParent("AccountType")]
        public string FACTYPE { get; set; }

        [MatchParent("AccountTypeNameENG")]
        public string FNAMEEN { get; set; }

        [MatchParent("AccountTypeNameTHA")]
        public string FNAMETH { get; set; }
    }
}
