using MBaseAPI.Models;
using System.Collections.Generic;

namespace MBaseAPI.Interfaces
{
    public interface ISQLService
    {
        MBaseHeader GetMBaseHeader(string tranCode);
        IEnumerable<MBaseMessageType> GetMBaseResponseMessages(string tranCode);
        IEnumerable<MBaseMessageType> GetMBaseHeaderMessages(string tranCode);
        IEnumerable<MBaseMessageType> GetMBaseInputMessages(string tranCode);
    }
}
