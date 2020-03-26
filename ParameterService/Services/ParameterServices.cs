using DataAccess;
using ParameterAPIService.Data;
using ParameterAPIService.Interfaces;
using ParameterAPIService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ParameterAPIService.Services
{
    public class ParameterServices : IParameterServices
    {
        private string KEY { get; set; } = string.Empty;
        private string VALUE { get; set; } = string.Empty;
        private string LIB { get; set; } = string.Empty;
        private string FILE { get; set; } = string.Empty;
        private string SQL { get; set; } = @"SELECT TRIM([KEY]) AS [KEY], TRIM([VALUE]) AS [VALUE] FROM [LIB]/[FILE]";
        //private readonly ApplicationDB2Context dB2Context;

        public ParameterServices()
        {
            //this.dB2Context = dB2Context;
        }


        public IEnumerable<ParameterModel> GetBOTOccupation(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetBusinessType(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetDocumentType(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetEducationLevel(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetOccupationRisk(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetPrefixName(ProjectAppSettings app)
        {
            return GetParameter(app);
        }
        public IEnumerable<ParameterModel> GetStatus(ProjectAppSettings app)
        {
            string[] cond = new string[1];
            cond[0] = "CP3UIC = '1'";

            return GetParameter(app, cond);
        }

        public IEnumerable<ParameterModel> GetParameter(ProjectAppSettings app, string[] condition = null)
        {
            KEY = app.KEY;
            VALUE = app.VALUE;
            FILE = app.FILE;
            LIB = app.ISTEST.Equals("Y")
                ? app.LHBDDATPAR
                : app.LHBPDATPAR;
            SQL = SQL
                .Replace($"[{ nameof(ProjectAppSettings.KEY) }]", KEY)
                .Replace($"[{ nameof(ProjectAppSettings.VALUE) }]", VALUE)
                .Replace($"[{ nameof(ProjectAppSettings.LIB) }]", LIB)
                .Replace($"[{ nameof(ProjectAppSettings.FILE) }]", FILE);

            if(condition != null)
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
        public IEnumerable<ParameterModel> ExecuteGetParameter(string sql)
        {
            List<ParameterModel> parameters = new List<ParameterModel>();
            try
            {
                AS400Singleton.AS400.ExecuteSql(sql, out DataTable dt, out string Message);
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
    }
}
