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
        public IEnumerable<FatcaResponseModel> Get()
        {
            List<FatcaResponseModel> models = new List<FatcaResponseModel>();
            DataTable dt = new DataTable();
            string oMessage = string.Empty;
            AS400Singleton.Instance.ExecuteSql("", out dt, out oMessage);
            models.Add(new FatcaResponseModel
            {
                CIF = "12345"
            });
            return models;
        }
    }
}