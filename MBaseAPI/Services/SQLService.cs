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
        private string SpName;
        private string oMessage;

        public IEnumerable<MBaseMessageType> GetMBaseResponseMessages(string tranCode)
        {
            return ExecuteStoreProcedure(tranCode, "R");
        }

        public IEnumerable<MBaseMessageType> GetMBaseHeaderMessages(string tranCode)
        {
            return ExecuteStoreProcedure(tranCode, "H");
        }

        public IEnumerable<MBaseMessageType> GetMBaseInputMessages(string tranCode)
        {
            return ExecuteStoreProcedure(tranCode, "I");
        }

        public MBaseHeader GetMBaseHeader(string transCode)
        {
            MBaseHeader mBase = new MBaseHeader();
            SpName = "mbase_getTransaction";
            SqlParameter[] param =
            {
                new SqlParameter("@transactionCode", SqlDbType.VarChar, 10) { Value = transCode }
            };

            if(!SQLSingleton.Instance.RunStoreProcedure(SpName, param, out DataTable oDt, out oMessage))
            {
                WriteLog(oMessage);
                return null;
            }

            foreach (DataRow row in oDt.Rows)
            {
                mBase = new MBaseHeader
                {
                    MBaseTranCode = row[nameof(MBaseHeader.MBaseTranCode)].ToString(),
                    ScenarioNumber = row[nameof(MBaseHeader.ScenarioNumber)].ToString(),
                    ActionMode = row[nameof(MBaseHeader.ActionMode)].ToString(),
                    TransactionMode = row[nameof(MBaseHeader.TransactionMode)].ToString(),
                    NoOfRecToRetrieve = row[nameof(MBaseHeader.NoOfRecToRetrieve)].ToString(),
                    InputLength = int.Parse(row[nameof(MBaseHeader.InputLength)].ToString()),
                    ResponseLength = int.Parse(row[nameof(MBaseHeader.ResponseLength)].ToString())
                };
            }

            return mBase;
        }


        private IEnumerable<MBaseMessageType> ExecuteStoreProcedure(string tranCode, string messageType)
        {
            List<MBaseMessageType> mBaseMessages = new List<MBaseMessageType>();
            SpName = @"mbase_getMessage";
            SqlParameter[] param =
            {
                new SqlParameter("@msgType", SqlDbType.VarChar, 5) { Value = messageType },
                new SqlParameter("@transactionCode", SqlDbType.VarChar, 10) { Value = tranCode }
            };

            if (SQLSingleton.Instance.RunStoreProcedure(SpName, param, out DataTable dt, out oMessage))
            {
                SetMBaseMessageValue(dt, ref mBaseMessages);
            }
            else
            {
                WriteLog(oMessage);
            }

            return mBaseMessages;
        }
        private void SetMBaseMessageValue(DataTable dt, ref List<MBaseMessageType> mBaseMessages)
        {
            foreach (DataRow row in dt.Rows)
            {
                mBaseMessages.Add(new MBaseMessageType
                {
                    MessageType = row[nameof(MBaseMessageType.MessageType)].ToString(),
                    TranCode = row[nameof(MBaseMessageType.TranCode)].ToString(),
                    Seq = int.Parse(row[nameof(MBaseMessageType.Seq)].ToString()),
                    FieldName = row[nameof(MBaseMessageType.FieldName)].ToString(),
                    Length = row[nameof(MBaseMessageType.Length)].ToString(),
                    DataType = row[nameof(MBaseMessageType.DataType)].ToString(),
                    StartIndex = int.Parse(row[nameof(MBaseMessageType.StartIndex)].ToString()),
                    EndIndex = int.Parse(row[nameof(MBaseMessageType.EndIndex)].ToString()),
                    Mandatory = row[nameof(MBaseMessageType.Mandatory)].ToString(),
                    Description = row[nameof(MBaseMessageType.Description)].ToString(),
                    DefaultValue = row[nameof(MBaseMessageType.DefaultValue)].ToString(),
                    Remark = row[nameof(MBaseMessageType.Remark)].ToString()
                });
            }
        }
        private void WriteLog(string message)
        {
            Logging.WriteLog(message);
        }
    }
}