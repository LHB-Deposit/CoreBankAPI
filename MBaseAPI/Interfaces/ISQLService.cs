using MBaseAPI.Models;
using System.Collections.Generic;

namespace MBaseAPI.Interfaces
{
    public interface ISQLService
    {
        HeaderTransactionModel GetHeaderTransaction(string tranCode);
        IEnumerable<MessageTypeModel> GetResponseMessages(string tranCode);
        IEnumerable<MessageTypeModel> GetHeaderMessage();
        IEnumerable<MessageTypeModel> GetInputMessages(string tranCode);

        void AddMBaseMessage(MessageTypeModel message);
    }
}
