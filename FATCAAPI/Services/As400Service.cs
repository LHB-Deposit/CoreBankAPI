using FATCAAPI.Interfaces;
using FATCAAPI.Models;
using iSeriesDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FATCAAPI.Services
{
    public class As400Service : IAs400Service
    {
        public IEnumerable<FlagResponseModel> Get()
        {
            List<FlagResponseModel> models = new List<FlagResponseModel>();
            DataTable dt = new DataTable();
            string oMessage = string.Empty;
            AS400Singleton.Instance.ExecuteSql("", out dt, out oMessage);
            models.Add(new FlagResponseModel
            {
                CIF = "12345"
            });
            return models;
        }
    }
}