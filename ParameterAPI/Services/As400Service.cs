using iSeriesDataAccess;
using ParameterAPI.Helpers;
using ParameterAPI.Interfaces;
using ParameterAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace ParameterAPI.Services
{
    public class As400Service : IAs400Service
    {
        private readonly IAppSettingService appSettingService;

        private string KEY { get; set; } = string.Empty;
        private string VALUE { get; set; } = string.Empty;
        private string LIB { get; set; } = string.Empty;
        private string FILE { get; set; } = string.Empty;
        private string SQL { get; set; } = @"SELECT TRIM([KEY]) AS [KEY], TRIM([VALUE]) AS [VALUE] FROM [LIB].[FILE]";

        public As400Service(IAppSettingService appSettingService)
        {
            this.appSettingService = appSettingService;
        }

        public IEnumerable<ParameterResponseModel> ExecuteGetParameter(string sql)
        {
            List<ParameterResponseModel> parameters = new List<ParameterResponseModel>();
            try
            {
                AS400Singleton.Instance.ExecuteSql(sql, out DataTable dt, out string Message);
                foreach (DataRow row in dt.Rows)
                {
                    parameters.Add(new ParameterResponseModel
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

        public IEnumerable<ParameterResponseModel> GetParameter(AS400AppSettingModel appSettings, string[] condition = null, string keyconcat = "")
        {
            LIB = appSettingService.GetLibrary(appSettings.File);
            FILE = appSettings.File;
            KEY = appSettings.Key;
            VALUE = appSettings.Value;
            if (!string.IsNullOrEmpty(keyconcat))
            {
                SQL = SQL
                .Replace($"[{ nameof(AppSettings.KEY) }]", KEY)
                .Replace($"TRIM({KEY})", $"{keyconcat}")
                .Replace($"[{ nameof(AppSettings.VALUE) }]", VALUE)
                .Replace($"[LIB]", LIB)
                .Replace($"[FILE]", FILE);
            }
            else
            {
                SQL = SQL
                .Replace($"[{ nameof(AppSettings.KEY) }]", KEY)
                .Replace($"[{ nameof(AppSettings.VALUE) }]", VALUE)
                .Replace($"[LIB]", LIB)
                .Replace($"[FILE]", FILE);
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

        public IEnumerable<ParameterResponseModel> GetBOTOccupation(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetBusinessType(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetDocumentType(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetEducationLevel(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetOccupation(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetOccupationRisk(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetPrefixName(AS400AppSettingModel appSettings)
        {
            var keyconcat = "TRIM(CFTTCD CONCAT '' CONCAT CFTTTP)";
            return GetParameter(appSettings, null, keyconcat);
        }

        public IEnumerable<ParameterResponseModel> GetStatus(AS400AppSettingModel appSettings)
        {
            string[] cond = new string[1];
            cond[0] = "CP3UIC = '1'";

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterResponseModel> GetAccountType(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetSourceOfIncome(AS400AppSettingModel appSettings)
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

        public IEnumerable<ParameterResponseModel> GetSourceOfIncomeCorp(AS400AppSettingModel appSettings)
        {
            string[] cond = {
                "CP9XIA = 'CF'",
                "CP9XIT = 'KYC'",
                "CP9XST = 'ASSETSRCN'",
                "CP9VTY = 'M'"
            };

            return GetParameter(appSettings, cond);
        }

        public IEnumerable<ParameterResponseModel> GetPurposeOfAccountOpen(AS400AppSettingModel appSettings)
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

        public IEnumerable<ParameterResponseModel> GetPurposeOfAccountOpenCorp(AS400AppSettingModel appSettings)
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

        public IEnumerable<ParameterResponseModel> GetSourceOfDeposit(AS400AppSettingModel appSettings)
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

        public IEnumerable<ParameterResponseModel> GetSourceOfDepositCorp(AS400AppSettingModel appSettings)
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

        public IEnumerable<ParameterResponseModel> GetCountry(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }
        public IEnumerable<ParameterResponseModel> GetState(AS400AppSettingModel appSettings)
        {
            var keyconcat = "TRIM(TRIM(SSSCOC) CONCAT '' CONCAT SSSTAC)";
            string[] cond =
            {
                "SSSCOC = 'TH'"
            };
            return GetParameter(appSettings, cond, keyconcat);
        }
        public IEnumerable<ParameterResponseModel> GetAddressType(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetFatcaDescription(AS400AppSettingModel appSettings)
        {
            return GetParameter(appSettings);
        }

        public IEnumerable<ParameterResponseModel> GetCountryRisk(AS400AppSettingModel appSettings)
        {
            AS400AppSettingModel countrySetting = new AS400AppSettingModel()
            {
                File = ConfigurationManager.AppSettings[nameof(AppSettings.CountryFile)].ToString(),
                Key = ConfigurationManager.AppSettings[nameof(AppSettings.CountryKey)].ToString(),
                Value = ConfigurationManager.AppSettings[nameof(AppSettings.CountryValue)].ToString()
            };

            var countryList = GetParameter(countrySetting);
            SQL = @"SELECT TRIM([KEY]) AS [KEY], TRIM([VALUE]) AS [VALUE] FROM [LIB].[FILE]";

            string[] cond =
            {
                "KCPCNR = 'Y'"
            };
            
            var coutryRiskList = GetParameter(appSettings, cond);

            return countryList.Where(s => coutryRiskList.Any(x => x.Key.Equals(s.Key)));
        }
    }
}