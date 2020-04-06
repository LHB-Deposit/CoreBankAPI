using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using SolutionUtility;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MBaseAPI.Services
{
    public class SQLService : ISQLService
    {
        private string SQL;
        private string SPName;
        private string oMessage;

        public IEnumerable<MBaseMessage> GetMBaseResponse(string transCode)
        {
            List<MBaseMessage> mBases = new List<MBaseMessage>();
            SPName = "mbase_getMessage";
            SqlParameter[] param =
            {
                new SqlParameter("@msgType", SqlDbType.VarChar, 5) { Value = "R" },
                new SqlParameter("@transactionCode", SqlDbType.VarChar, 10) { Value = transCode }
            };

            if(!SQLSingleton.Instance.RunStoreProcedure(SPName, param, out DataTable oDt, out oMessage))
            {
                WriteLog(oMessage);
                return null;
            }

            foreach (DataRow row in oDt.Rows)
            {
                mBases.Add(new MBaseMessage
                {
                    MessageType = row[nameof(MBaseMessage.MessageType)].ToString(),
                    TranCode = row[nameof(MBaseMessage.TranCode)].ToString(),
                    Seq = int.Parse(row[nameof(MBaseMessage.Seq)].ToString()),
                    FieldName = row[nameof(MBaseMessage.FieldName)].ToString(),
                    Length = row[nameof(MBaseMessage.Length)].ToString(),
                    DataType = row[nameof(MBaseMessage.DataType)].ToString(),
                    StartIndex = int.Parse(row[nameof(MBaseMessage.StartIndex)].ToString()),
                    EndIndex = int.Parse(row[nameof(MBaseMessage.EndIndex)].ToString()),
                    Mandatory = row[nameof(MBaseMessage.Mandatory)].ToString(),
                    Description = row[nameof(MBaseMessage.Description)].ToString(),
                    DefaultValue = row[nameof(MBaseMessage.DefaultValue)].ToString(),
                    Remark = row[nameof(MBaseMessage.Remark)].ToString()
                });
            }

            return mBases;
        }

        public MBaseTransaction GetMBaseTransaction(string transCode)
        {
            MBaseTransaction mBase = new MBaseTransaction();
            SPName = "mbase_getTransaction";
            SqlParameter[] param =
            {
                new SqlParameter("@transactionCode", SqlDbType.VarChar, 10) { Value = transCode }
            };

            if(!SQLSingleton.Instance.RunStoreProcedure(SPName, param, out DataTable oDt, out oMessage))
            {
                WriteLog(oMessage);
                return null;
            }

            foreach (DataRow row in oDt.Rows)
            {
                mBase = new MBaseTransaction
                {
                    MBaseTranCode = row[nameof(MBaseTransaction.MBaseTranCode)].ToString(),
                    ScenarioNumber = row[nameof(MBaseTransaction.ScenarioNumber)].ToString(),
                    ActionMode = row[nameof(MBaseTransaction.ActionMode)].ToString(),
                    TransactionMode = row[nameof(MBaseTransaction.TransactionMode)].ToString(),
                    NoOfRecToRetrieve = row[nameof(MBaseTransaction.NoOfRecToRetrieve)].ToString(),
                    InputLength = int.Parse(row[nameof(MBaseTransaction.InputLength)].ToString()),
                    ResponseLength = int.Parse(row[nameof(MBaseTransaction.ResponseLength)].ToString())
                };
            }

            return mBase;
        }


        private void WriteLog(string message)
        {
            Logging.WriteLog(message);
        }
    }
}