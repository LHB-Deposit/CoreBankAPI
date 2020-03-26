using IBM.Data.DB2.Core;
using System;
using System.Data;

namespace DataAccess
{
    public sealed class AS400Singleton
    {
        private AS400Singleton() { }

        private static AS400Singleton as400 = null;

        private DB2Connection _conn;
        private DB2Command _command;
        private DB2DataAdapter _adapter;

        public string ConnectionString { get; set; }
        public int DbTimeOut { get; } = 180;

        public static AS400Singleton AS400
        {
            get
            {
                if(as400 == null)
                {
                    as400 = new AS400Singleton();
                }
                return as400;
            }
        }

        public bool ExecuteSql(string sql, out DataTable oDataTable, out string oMessage)
        {
            bool res = false;
            oMessage = string.Empty;
            oDataTable = new DataTable();
            try
            {
                _conn = new DB2Connection(ConnectionString);
                _conn.Open();
                _command = new DB2Command(sql, _conn)
                {
                    CommandTimeout = DbTimeOut
                };

                _adapter = new DB2DataAdapter
                {
                    SelectCommand = _command
                };

                _adapter.Fill(oDataTable);

                res = true;
            }
            catch (Exception ex)
            {
                oMessage = ex.Message;
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
