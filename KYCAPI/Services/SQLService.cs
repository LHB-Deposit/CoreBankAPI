using KYCAPI.Interfaces;
using KYCAPI.Models;
using SolutionUtility;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KYCAPI.Services
{
    public class SQLService : ISQLService
    {
        private string SpName;
        private string oMessage;

        public IEnumerable<MessageTypeModel> GetResponseMessages(string tranCode)
        {
            return ExecuteStoreProcedure("R", tranCode);
        }
        public IEnumerable<MessageTypeModel> GetHeaderMessage()
        {
            return ExecuteStoreProcedure("H");
        }
        public IEnumerable<MessageTypeModel> GetInputMessages(string tranCode)
        {
            return ExecuteStoreProcedure("I", tranCode);
        }
        public HeaderTransactionModel GetHeaderTransaction(string transCode)
        {
            HeaderTransactionModel mBase = new HeaderTransactionModel();
            SpName = "mbase_getTransaction";
            SqlParameter[] param =
            {
                new SqlParameter("@MBaseTranCode", SqlDbType.VarChar, 10) { Value = transCode }
            };

            if (!SQLSingleton.Instance.RunStoreProcedure(SpName, param, out DataTable oDt, out oMessage))
            {
                Logging.WriteLog(oMessage);
                return null;
            }

            foreach (DataRow row in oDt.Rows)
            {
                mBase = new HeaderTransactionModel
                {
                    MBaseTranCode = row[nameof(HeaderTransactionModel.MBaseTranCode)].ToString(),
                    ScenarioNumber = row[nameof(HeaderTransactionModel.ScenarioNumber)].ToString(),
                    ActionMode = row[nameof(HeaderTransactionModel.ActionMode)].ToString(),
                    TransactionMode = row[nameof(HeaderTransactionModel.TransactionMode)].ToString(),
                    NoOfRecToRetrieve = row[nameof(HeaderTransactionModel.NoOfRecToRetrieve)].ToString(),
                    InputLength = int.Parse(row[nameof(HeaderTransactionModel.InputLength)].ToString()),
                    ResponseLength = int.Parse(row[nameof(HeaderTransactionModel.ResponseLength)].ToString())
                };
            }

            return mBase;
        }

        private IEnumerable<MessageTypeModel> ExecuteStoreProcedure(string messageType, string tranCode = null)
        {
            List<MessageTypeModel> mBaseMessages = new List<MessageTypeModel>();
            SqlParameter[] param;
            if (tranCode == null)
            {
                SpName = "mbase_getHeaderMessage";
                SqlParameter[] paraHeader =
                {
                    new SqlParameter("@MessageType", SqlDbType.VarChar, 5) { Value = messageType }
                };
                param = paraHeader;
            }
            else
            {
                SpName = @"mbase_getMessage";

                SqlParameter[] paraMessage =
                {
                    new SqlParameter("@MessageType", SqlDbType.VarChar, 5) { Value = messageType },
                    new SqlParameter("@TranCode", SqlDbType.VarChar, 10) { Value = tranCode }
                };
                param = paraMessage;
            }


            if (SQLSingleton.Instance.RunStoreProcedure(SpName, param, out DataTable dt, out oMessage))
            {
                SetMBaseMessageValue(dt, ref mBaseMessages);
            }
            else
            {
                Logging.WriteLog(oMessage);
            }

            return mBaseMessages;
        }
        private void SetMBaseMessageValue(DataTable dt, ref List<MessageTypeModel> mBaseMessages)
        {
            foreach (DataRow row in dt.Rows)
            {
                mBaseMessages.Add(new MessageTypeModel
                {
                    MessageType = row[nameof(MessageTypeModel.MessageType)].ToString(),
                    TranCode = row[nameof(MessageTypeModel.TranCode)].ToString(),
                    Seq = int.Parse(row[nameof(MessageTypeModel.Seq)].ToString()),
                    FieldName = row[nameof(MessageTypeModel.FieldName)].ToString(),
                    Length = row[nameof(MessageTypeModel.Length)].ToString(),
                    DataType = row[nameof(MessageTypeModel.DataType)].ToString(),
                    StartIndex = int.Parse(row[nameof(MessageTypeModel.StartIndex)].ToString()),
                    EndIndex = int.Parse(row[nameof(MessageTypeModel.EndIndex)].ToString()),
                    Mandatory = row[nameof(MessageTypeModel.Mandatory)].ToString(),
                    Description = row[nameof(MessageTypeModel.Description)].ToString(),
                    DefaultValue = row[nameof(MessageTypeModel.DefaultValue)].ToString(),
                    Remark = row[nameof(MessageTypeModel.Remark)].ToString()
                });
            }
        }
    }
}