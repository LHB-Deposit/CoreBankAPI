using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class MBaseHeaderTransaction
    {
        public string MBaseTranCode { get; set; }
        public string ScenarioNumber { get; set; }
        public string ActionMode { get; set; }
        public string TransactionMode { get; set; }
        public string NoOfRecToRetrieve { get; set; }
        public int InputLength { get; set; }
        public int ResponseLength { get; set; }
        public string Description { get; set; }
    }
}
