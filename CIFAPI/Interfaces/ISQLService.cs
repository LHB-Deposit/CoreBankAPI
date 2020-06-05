using CIFAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFAPI.Interfaces
{
    public interface ISQLService
    {
        HeaderTransactionModel GetHeaderTransaction(string tranCode);
        IEnumerable<MessageTypeModel> GetResponseMessages(string tranCode);
        IEnumerable<MessageTypeModel> GetHeaderMessage();
        IEnumerable<MessageTypeModel> GetInputMessages(string tranCode);
    }
}
