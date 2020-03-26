using iSeriesAPIService.Helpers;
using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Models;
using iSeriesDataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace iSeriesAPIService.Services
{
    public class ParameterService : IParameterService
    {
        private string KEY { get; set; } = string.Empty;
        private string VALUE { get; set; } = string.Empty;
        private string LIB { get; set; } = string.Empty;
        private string FILE { get; set; } = string.Empty;
        private string SQL { get; set; } = @"SELECT TRIM([KEY]) AS [KEY], TRIM([VALUE]) AS [VALUE] FROM [LIB].[FILE]";
        public IEnumerable<ParameterModel> ExecuteGetParameter(string sql)
        {
            List<ParameterModel> parameters = new List<ParameterModel>();
            try
            {
                AS400Singleton.Instance.ExecuteSql(sql, out DataTable dt, out string Message);
                foreach (DataRow row in dt.Rows)
                {
                    parameters.Add(new ParameterModel
                    {
                        Key = row[KEY].ToString(),
                        Value = row[VALUE].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
            return parameters;
        }
        public IEnumerable<ParameterModel> GetParameter(AppSettings app, string[] condition = null)
        {
            KEY = app.KEY;
            VALUE = app.VALUE;
            FILE = app.FILE;
            LIB = ConfigurationManager.AppSettings[nameof(AppSettings.ISTEST)].ToString().Equals("Y")
                ? ConfigurationManager.AppSettings[nameof(AppSettings.LHBDDATPAR)].ToString()
                : ConfigurationManager.AppSettings[nameof(AppSettings.LHBPDATPAR)].ToString();
            SQL = SQL
                .Replace($"[{ nameof(AppSettings.KEY) }]", KEY)
                .Replace($"[{ nameof(AppSettings.VALUE) }]", VALUE)
                .Replace($"[{ nameof(AppSettings.LIB) }]", LIB)
                .Replace($"[{ nameof(AppSettings.FILE) }]", FILE);

            if (condition != null)
            {
                if (condition.Length > 0)
                {
                    for (int i = 0; i < condition.Length; i++)
                    {
                        if (i == 0)
                            SQL += " WHERE " + condition[i];
                        else
                            SQL += " AND " + condition[i];
                    }
                }
            }

            return ExecuteGetParameter(SQL);
        }

        public IEnumerable<ParameterModel> GetBOTOccupation(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetBusinessType(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetDocumentType(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetEducationLevel(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetOccupationRisk(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetPrefixName(AppSettings app)
        {
            return GetParameter(app);
        }

        public IEnumerable<ParameterModel> GetStatus(AppSettings app)
        {
            string[] cond = new string[1];
            cond[0] = "CP3UIC = '1'";

            return GetParameter(app, cond);
        }
    }
}