using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATCAAPI.Interfaces
{
    public interface IAppSettingService
    {
        string GetLibrary(string fileName);
        string GetLibJob(string jobName);
    }
}
