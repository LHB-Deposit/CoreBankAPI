using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess
{
    public sealed class SQLSingleton
    {
        private static SQLSingleton sQLSingleton = null;
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        private SQLSingleton() { }

        public static SQLSingleton Instance
        {
            get
            {
                if(sQLSingleton == null)
                {
                    sQLSingleton = new SQLSingleton();
                }
                return sQLSingleton;
            }
        }
        private int DbTimeout
        {
            get
            {
                try { return Convert.ToInt16(ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DbTimeout)].ToString()); }
                catch { return 180; }
            }
        }

        public static string GetConnectionString()
        {
            bool IsTest = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.ISTEST)].ToString().Equals("Y") ? true : false;
            string connectionString;
            string user;
            string pass;
            if (IsTest)
            {
                if (ConfigurationManager.AppSettings[nameof(ProjectAppSettings.UseLocalDB)].ToString().Equals("Y"))
                {
                    connectionString = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.Local_SQLConnection)].ToString();
                }
                else
                {
                    connectionString = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_SQLConnection)].ToString();
                    user = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_SQL_USERID)].ToString();
                    pass = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.DEV_SQL_PASSWD)].ToString();
                    connectionString = connectionString
                        .Replace($"[{ nameof(ProjectAppSettings.DEV_SQL_USERID) }]", Cryptography.DecryptString(user))
                        .Replace($"[{ nameof(ProjectAppSettings.DEV_SQL_PASSWD) }]", Cryptography.DecryptString(pass));
                }
            }
            else
            {
                connectionString = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_SQLConnection)].ToString();
                user = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_SQL_USERID)].ToString();
                pass = ConfigurationManager.AppSettings[nameof(ProjectAppSettings.PRD_SQL_PASSWD)].ToString();
                connectionString = connectionString
                    .Replace($"[{ nameof(ProjectAppSettings.PRD_SQL_USERID) }]", Cryptography.DecryptString(user))
                    .Replace($"[{ nameof(ProjectAppSettings.PRD_SQL_PASSWD) }]", Cryptography.DecryptString(pass));
            }

            return connectionString;
        }

        public bool ExecuteSql(string Sql, out string Reason)
        {
            Reason = string.Empty;
            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();
                command = new SqlCommand(Sql, conn);
                command.ExecuteNonQuery();
                conn.Close();

                Reason = string.Empty;
                return true;
            }
            catch (SqlException e1)
            {
                Reason += e1.Message;
                return false;
            }
            catch (Exception e2)
            {
                Reason = e2.Message;
                return false;
            }
        }

        public bool ExecuteSql(string[] sql, out string Reason)
        {
            Reason = "";
            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                SqlTransaction transaction = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = transaction;

                int count = 0;
                string i_sql = string.Empty;
                try
                {

                    for (int i = 0; i < sql.Length; i++)
                    {
                        if (sql[i] != null)
                        {
                            i_sql = sql[i].Trim();
                            if (!i_sql.Equals(string.Empty))
                            {
                                command.CommandText = i_sql;
                                command.ExecuteNonQuery();
                                count++;
                            }
                        }
                    }

                    transaction.Commit();
                    conn.Close();

                    return true;
                }
                catch (SqlException e1)
                {
                    transaction.Rollback();

                    Reason = e1.Message;
                    return false;
                }
                catch (Exception e2)
                {
                    transaction.Rollback();
                    Reason = e2.Message;
                    Reason += count.ToString() + " " + i_sql;
                    return false;
                }

            }
            catch (SqlException ex)
            {
                Reason = ex.Message;
                return false;
            }
            catch (Exception e)
            {
                Reason = e.Message;
                return false;
            }
        }

        public bool ExecuteSql(string Sql, string tableName, out DataSet oDataset, out string Reason)
        {
            oDataset = new DataSet();
            Reason = "";
            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                SqlCommand Command = new SqlCommand(Sql, conn);
                Command.CommandTimeout = DbTimeout;

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = Command;
                adapter.Fill(oDataset, tableName);

                //Adapter = new SqlDataAdapter(Sql, Conn);
                //Adapter.Fill(oDataset, tableName);

                conn.Close();
                Reason = string.Empty;
                return true;
            }
            catch (SqlException e1)
            {
                Reason = e1.Message;
                return false;
            }
            catch (Exception e2)
            {
                Reason = e2.Message;
                return false;
            }
        }

        public bool ExecuteSql(string Sql, out DataTable oTable, out string Reason)
        {
            oTable = new DataTable();
            Reason = Sql;
            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                SqlCommand Command = new SqlCommand(Sql, conn);
                Command.CommandTimeout = DbTimeout;

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = Command;
                adapter.Fill(oTable);



                //Adapter = new SqlDataAdapter(Sql, Conn);
                //Adapter.Fill(oTable);

                conn.Close();
                Reason = string.Empty;
                return true;
            }
            catch (SqlException e1)
            {
                Reason += Environment.NewLine + e1.Message;
                return false;
            }
            catch (Exception e2)
            {
                Reason += Environment.NewLine + e2.Message;
                return false;
            }
        }

        public bool ExecuteSql(string Sql, out DataRow oRow, out string Reason)
        {
            oRow = null;
            Reason = "";
            try
            {
                DataTable dt = new DataTable();
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                //Adapter = new SqlDataAdapter(Sql, Conn);
                //Adapter.Fill(dt);

                SqlCommand Command = new SqlCommand(Sql, conn);
                Command.CommandTimeout = DbTimeout;

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = Command;
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    oRow = dt.Rows[0];

                conn.Close();

                return true;
            }
            catch (SqlException e1)
            {
                Reason = e1.Message;
                return false;
            }
            catch (Exception e2)
            {
                Reason = e2.Message;
                return false;
            }
        }

        public bool ExecuteSql(string Sql, out string oString, out string Reason)
        {
            DataTable dt = new DataTable();
            oString = ""; Reason = "";
            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();
                adapter = new SqlDataAdapter(Sql, conn);
                adapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr != null)
                        oString = dr[0].ToString();
                }


                conn.Close();

                return true;
            }
            catch (SqlException e1)
            {
                Reason = e1.Message;
                return false;
            }
            catch (Exception e2)
            {
                Reason = e2.Message;
                return false;
            }
        }

        public void RunStoreProcedure(string SpName, SqlParameter[] ParameterIn, out string oString)
        {
            oString = "";

            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SpName,
                    Connection = conn
                };

                command.Parameters.Clear();

                for (var i = 0; i < ParameterIn.Length; i++)
                    command.Parameters.Add(ParameterIn[i]);

                oString = command.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(conn != null)
                    if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
        public bool RunStoreProcedure(string SpName, SqlParameter[] ParameterIn, out DataTable oDataTable, out string oMessage)
        {
            oMessage = string.Empty;
            oDataTable = new DataTable();
            bool res = false;

            try
            {
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SpName;
                command.Connection = conn;

                command.Parameters.Clear();

                for (int i = 0; i < ParameterIn.Length; i++)
                    command.Parameters.Add(ParameterIn[i]);

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(oDataTable);


                res = true;
            }
            catch (Exception ex)
            {
                oMessage = ex.Message;
                Logging.WriteLog(ex.Message);
            }

            return res;
        }
        public bool RunStoreProcedure(string SpName, SqlParameter[] ParameterIn, out DataRow oDataRow, out string oMessage)
        {
            oMessage = string.Empty;
            oDataRow = null;
            bool res = false;

            try
            {
                DataTable dt = new DataTable();
                conn = new SqlConnection(GetConnectionString());
                conn.Open();

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SpName;
                command.Connection = conn;

                command.Parameters.Clear();

                for (int i = 0; i < ParameterIn.Length; i++)
                    command.Parameters.Add(ParameterIn[i]);

                adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);

                if (dt.Rows.Count > 0) oDataRow = dt.Rows[0];

                res = true;
            }
            catch (Exception ex)
            {
                oMessage = ex.Message;
                Logging.WriteLog(ex.Message);
            }

            return res;
        }
    }
}
