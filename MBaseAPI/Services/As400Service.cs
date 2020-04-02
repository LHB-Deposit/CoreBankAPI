using MBaseAccess;
using MBaseAPI.Helpers;
using MBaseAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBaseAPI.Services
{
    public class As400Service : IAs400Service
    {
        public CIFLevelResponse ExecuteGetParameter(string sql)
        {
            throw new NotImplementedException();
        }

        public CIFLevelResponse GetParameter(AppSettings app, string[] condition = null)
        {
            throw new NotImplementedException();
        }
    }
}