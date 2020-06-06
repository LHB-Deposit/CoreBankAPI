using System;
using System.Collections.Generic;
using System.Configuration;

namespace SolutionUtility
{
    public class ProjectAppSettings
    {
        public string SECRET { get; set; }
        public string Expiration { get; set; }
        public int DbTimeout { get; set; }
        public string Local_SQLConnection { get; set; }
        public string DEV_SQLConnection { get; set; }
        public string PRD_SQLConnection { get; set; }
        public string DEV_AS400Connection { get; set; }
        public string PRD_AS400Connection { get; set; }
        public string DEV_SQL_USERID { get; set; }
        public string DEV_SQL_PASSWD { get; set; }
        public string DEV_AS400_USERID { get; set; }
        public string DEV_AS400_PASSWD { get; set; }
        public string PRD_SQL_USERID { get; set; }
        public string PRD_SQL_PASSWD { get; set; }
        public string PRD_AS400_USERID { get; set; }
        public string PRD_AS400_PASSWD { get; set; }
        public string DEV_AS400_LIB { get; set; }
        public string PRD_AS400_LIB { get; set; }
        public string DEV_AS400_LIBJOB { get; set; }
        public string PRD_AS400_LIBJOB { get; set; }

        public string AS400_LIB { get; set; }
        public string AS400_FILES { get; set; }
        public string AS400_OUTFILE { get; set; }
        public string AS400_JOBNAME { get; set; }
        public string ISTEST { get; set; }
        public string UseLocalDB { get; set; }
        public string LIB { get; set; }
        public string FILE { get; set; }
        public string KEY { get; set; }
        public string VALUE { get; set; }

        public Dictionary<string, string> APPSETTING_LIB { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> APPSETTING_FILE { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> APPSETTING_OUTFILE { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> APPSETTING_JOBNAME { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> APPSETTING_LIBJOB { get; set; } = new Dictionary<string, string>();

        public ProjectAppSettings()
        {
            InitializeEnvironment();
        }

        protected void InitializeEnvironment()
        {
            try
            {
                ISTEST = GetValueAndValidateAppSetting(nameof(ISTEST));
                if (!string.IsNullOrEmpty(ISTEST))
                {
                    string appsettingLib, appsettingFile, appsettingOutFile, appsettingJobName, appsettingLibJob;
                    if (ISTEST.ToUpper().Equals("N"))
                    {
                        appsettingLib = GetValueAndValidateAppSetting(nameof(PRD_AS400_LIB));
                        appsettingLibJob = GetValueAndValidateAppSetting(nameof(PRD_AS400_LIBJOB));
                        InitializeAppSettingLIB(appsettingLib);
                        InitializeAppSettingLibJob(appsettingLibJob);
                    }
                    else
                    {
                        appsettingLib = GetValueAndValidateAppSetting(nameof(DEV_AS400_LIB));
                        appsettingLibJob = GetValueAndValidateAppSetting(nameof(DEV_AS400_LIBJOB));
                        InitializeAppSettingLIB(appsettingLib);
                        InitializeAppSettingLibJob(appsettingLibJob);
                    }

                    appsettingFile = GetValueAndValidateAppSetting(nameof(AS400_FILES));
                    appsettingOutFile = GetValueAndValidateAppSetting(nameof(AS400_OUTFILE));
                    appsettingJobName = GetValueAndValidateAppSetting(nameof(AS400_JOBNAME));
                    InitializeAppSettingFile(appsettingFile);
                    InitializeAppSettingOutFile(appsettingOutFile);
                    InitializeAppSettingJobName(appsettingJobName);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
        }
        protected string GetValueAndValidateAppSetting(string key)
        {
            string value;
            try
            {
                value = ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                throw new Exception($"{key} not found.");
            }
            return value;
        }
        protected void InitialAppSetting(Dictionary<string, string> dictApp, string appKey)
        {
            string[] values = appKey.Split(',');
            foreach (var file in values)
            {
                dictApp.Add(file.Trim(), file.Trim());
            }
        }
        protected void InitializeAppSettingLIB(string app)
        {
            InitialAppSetting(APPSETTING_LIB, app);
        }
        protected void InitializeAppSettingFile(string app)
        {
            InitialAppSetting(APPSETTING_FILE, app);
        }
        protected void InitializeAppSettingOutFile(string app)
        {
            InitialAppSetting(APPSETTING_OUTFILE, app);
        }
        protected void InitializeAppSettingJobName(string app)
        {
            InitialAppSetting(APPSETTING_JOBNAME, app);
        }
        protected void InitializeAppSettingLibJob(string app)
        {
            InitialAppSetting(APPSETTING_LIBJOB, app);
        }
    }
}
