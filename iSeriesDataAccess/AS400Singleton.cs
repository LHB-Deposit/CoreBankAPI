using IBM.Data.DB2.iSeries;
using System;
using System.Configuration;
using System.Data;

namespace iSeriesDataAccess
{
    public sealed class AS400Singleton
    {
        private AS400Singleton() { }

        private static AS400Singleton as400 = null;
        private iDB2Connection _conn;
        private iDB2Command _command;
        private iDB2DataAdapter _adapter;

        public static string ConnectionString { get; set; } = string.Empty;
        public int DbTimeOut { get; } = 180;

        public static AS400Singleton Instance
        {
            get
            {
                if (as400 == null)
                {
                    as400 = new AS400Singleton();
                    SetAS400Configs();
                }
                return as400;
            }
        }

        private static void SetAS400Configs()
        {
            string as400conn;
            string as400User;
            string as400Pass;
            bool isTest = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.ISTEST)].ToString().Equals("Y") ? true : false; 
            
            if (isTest)
            {
                as400conn = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_AS400Connection)].ToString();
                as400User = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_AS400_USERID)].ToString();
                as400Pass = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_AS400_PASSWD)].ToString();
                ConnectionString = as400conn
                    .Replace($"[{ nameof(ProjectAppSettings.DEV_AS400_USERID) }]", Cryptography.DecryptString(as400User))
                    .Replace($"[{ nameof(ProjectAppSettings.DEV_AS400_PASSWD) }]", Cryptography.DecryptString(as400Pass));
            }
            else
            {
                as400conn = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_AS400Connection)].ToString();
                as400User = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_AS400_USERID)].ToString();
                as400Pass = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_AS400_PASSWD)].ToString();
                ConnectionString = as400conn
                    .Replace($"[{ nameof(ProjectAppSettings.PRD_AS400_USERID) }]", Cryptography.DecryptString(as400User))
                    .Replace($"[{ nameof(ProjectAppSettings.PRD_AS400_PASSWD) }]", Cryptography.DecryptString(as400Pass));
            }
        }
        public bool ExecuteSql(string sql, out DataTable oDataTable, out string oMessage)
        {
            bool res = false;
            oMessage = string.Empty;
            oDataTable = new DataTable();
            try
            {
                _conn = new iDB2Connection(ConnectionString);
                _conn.Open();
                _command = new iDB2Command(sql, _conn)
                {
                    CommandTimeout = DbTimeOut
                };

                _adapter = new iDB2DataAdapter
                {
                    SelectCommand = _command
                };

                _adapter.Fill(oDataTable);

                res = true;
            }
            catch (Exception ex)
            {
                oMessage = ex.Message;
                Logging.WriteLog(ex.Message);
            }
            finally
            {
                if (_conn != null)
                    if (_conn.State == ConnectionState.Open) _conn.Close();
            }
            return res;
        }
    }
}
