using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsentAPI.Interfaces
{
    public interface IAppSettingService
    {
        string GetLibrary(string fileName);
    }
}
