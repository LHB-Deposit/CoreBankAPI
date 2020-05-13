using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class MBaseMessage
    {
        public MBaseHeaderTransaction Header { get; set; }
        public IEnumerable<MBaseMessageType> HeaderMessages { get; set; }
        public IEnumerable<MBaseMessageType> InputMessages { get; set; }
        public IEnumerable<MBaseMessageType> ResponseMessages { get; set; }
    }
}
