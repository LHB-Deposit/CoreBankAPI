using MBaseAPI.Models;
using System.Collections.Generic;

namespace MBaseAPI.Interfaces
{
    public interface ISQLService
    {
        MBaseTransaction GetMBaseTransaction(string transCode);
        IEnumerable<MBaseMessage> GetMBaseResponse(string transCode);
    }
}
