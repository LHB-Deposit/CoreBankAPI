using iSeriesDataAccess;
using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace ParameterAPI.Services
{
    public class As400Service : IAs400Service
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

        public IEnumerable<ParameterModel> GetParameter(AppSettings appSettings, string[] condition = null, string keyconcat = "")
        {
            LIB = appSettings.LIB;
            FILE = appSettings.FILE;
            KEY = appSettings.KEY;
            VALUE = appSettings.VALUE;
            if (!string.IsNullOrEmpty(keyconcat))
            {
                SQL = SQL
                .Replace($"[{ nameof(AppSettings.KEY) }]", KEY)
                .Replace($"TRIM({KEY})", $"{keyconcat}")
                .Replace($"[{ nameof(AppSettings.VALUE) }]", VALUE)
                .Replace($"[{ nameof(AppSettings.LIB) }]", LIB)
                .Replace($"[{ nameof(AppSettings.FILE) }]", FILE);
            }
            else
            {
                SQL = SQL
                .Replace($"[{ nameof(AppSettings.KEY) }]", KEY)
                .Replace($"[{ nameof(AppSettings.VALUE) }]", VALUE)
                .Replace($"[{ nameof(AppSettings.LIB) }]", LIB)
                .Replace($"[{ nameof(AppSettings.FILE) }]", FILE);
            }
            

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

        public IEnumerable<ParameterModel> GetBOTOccupation(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetBusinessType(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetDocumentType(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetEducationLevel(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetOccupation(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetOccupationRisk(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetPrefixName(AppSettings appSettings)
        {
            var keyconcat = "TRIM(CFTTCD CONCAT '' CONCAT CFTTTP)";
            return GetParameter(appSettings, null, keyconcat);
        }

        public IEnumerable<ParameterModel> GetStatus(AppSettings appSettings)
        {
            string[] cond = new string[1];
            cond[0] = "CP3UIC = '1'";

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetAccountType(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetSourceOfIncome(AppSettings appSettings)
        {
            string[] cond = 
            { 
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'ASSETSRC'",
                "CP9VTY = 'M'"
            };

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetSourceOfIncomeCorp(AppSettings appSettings)
        {
            string[] cond = {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'ASSETSRCN'",
                "CP9VTY = 'M'"
            };

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetPurposeOfAccountOpen(AppSettings appSettings)
        {
            string[] cond =
            {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'DEPPURINV'",
                "CP9VTY = 'M'"
            };
            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetPurposeOfAccountOpenCorp(AppSettings appSettings)
        {
            string[] cond =
            {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'DEPPURNON'",
                "CP9VTY = 'M'"
            };
            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetSourceOfDeposit(AppSettings appSettings)
        {
            string[] cond =
            {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'DEPSRCINV'",
                "CP9VTY = 'M'"
            };

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetSourceOfDepositCorp(AppSettings appSettings)
        {
            string[] cond =
            {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'DEPSRCNON'",
                "CP9VTY = 'M'"
            };

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterModel> GetCountry(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }
        public IEnumerable<ParameterModel> GetState(AppSettings appSettings)
        {
            var keyconcat = "TRIM(TRIM(SSSCOC) CONCAT '' CONCAT SSSTAC)";
            string[] cond =
            {
                "SSSCOC = 'TH'"
            };
            return GetParameter(appSettings, cond, keyconcat);
        }
        public IEnumerable<ParameterModel> GetAddressType(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterModel> GetFatcaDescription(AppSettings appSettings)
        {
            return GetParameter(appSettings);
        }
    }
}