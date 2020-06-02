using FATCAAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATCAAPI.Interfaces
{
    public interface IAs400Service
    {
        IEnumerable<FlagResponseModel> Get();
    }
}
