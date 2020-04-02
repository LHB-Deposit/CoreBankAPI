using MBaseAccess;
using MBaseAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAPI.Interfaces
{
    public interface IAs400Service
    {
        CIFLevelResponse GetParameter(AppSettings app, string[] condition = null);
        CIFLevelResponse ExecuteGetParameter(string sql);
    }
}
