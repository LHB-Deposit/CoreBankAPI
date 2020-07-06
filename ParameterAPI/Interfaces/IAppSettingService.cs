using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParameterAPI.Interfaces
{
    public interface IAppSettingService
    {
        string GetLibrary(string fileName);
    }
}