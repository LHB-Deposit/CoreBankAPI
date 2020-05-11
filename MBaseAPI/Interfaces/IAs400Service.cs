using MBaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAPI.Interfaces
{
    public interface IAs400Service
    {
        IEnumerable<MBaseMessageTypeModel> GetMBaseResponseMessages(string tranCode);
        IEnumerable<MBaseMessageTypeModel> GetMBaseHeaderMessages(string tranCode);
        IEnumerable<MBaseMessageTypeModel> GetMBaseMessages(MBaseParameterModel model);
    }
}
