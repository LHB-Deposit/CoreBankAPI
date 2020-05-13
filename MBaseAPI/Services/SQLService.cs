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

        public IEnumerable<MBaseMessageTypeModel> GetMBaseResponseMessages(string tranCode)
        {
            return ExecuteStoreProcedure("R", tranCode);
        }

        public IEnumerable<MBaseMessageTypeModel> GetMBaseHeaderTransaction()
        {
            return ExecuteStoreProcedure("H");
        }

        public IEnumerable<MBaseMessageTypeModel> GetMBaseInputMessages(string tranCode)
        {
            return ExecuteStoreProcedure("I", tranCode);
        }

        public MBaseHeaderModel GetMBaseHeader(string transCode)
        {
            MBaseHeaderModel mBase = new MBaseHeaderModel();
            SpName = "mbase_getTransaction";
            SqlParameter[] param =
            {
                new SqlParameter("@MBaseTranCode", SqlDbType.VarChar, 10) { Value = transCode }
            };

            if(!SQLSingleton.Instance.RunStoreProcedure(SpName, param, out DataTable oDt, out oMessage))
            {
                WriteLog(oMessage);
                return null;
            }

            foreach (DataRow row in oDt.Rows)
            {
                mBase = new MBaseHeaderModel
                {
                    MBaseTranCode = row[nameof(MBaseHeaderModel.MBaseTranCode)].ToString(),
                    ScenarioNumber = row[nameof(MBaseHeaderModel.ScenarioNumber)].ToString(),
                    ActionMode = row[nameof(MBaseHeaderModel.ActionMode)].ToString(),
                    TransactionMode = row[nameof(MBaseHeaderModel.TransactionMode)].ToString(),
                    NoOfRecToRetrieve = row[nameof(MBaseHeaderModel.NoOfRecToRetrieve)].ToString(),
                    InputLength = int.Parse(row[nameof(MBaseHeaderModel.InputLength)].ToString()),
                    ResponseLength = int.Parse(row[nameof(MBaseHeaderModel.ResponseLength)].ToString())
                };
            }

            return mBase;
        }

        public void AddMBaseMessage(MBaseMessageTypeModel message)
        {
            SpName = "mbase_saveMessage";

            try
            {
                SqlParameter[] param =
                    {
                        new SqlParameter("@MessageType", SqlDbType.VarChar, 5){ Value = message.MessageType },
                        new SqlParameter("@TranCode", SqlDbType.VarChar, 5){ Value = message.TranCode },
                        new SqlParameter("@Seq", SqlDbType.Int){ Value = message.Seq },
                        new SqlParameter("@FieldName", SqlDbType.VarChar, 20){ Value = message.FieldName },
                        new SqlParameter("@Length", SqlDbType.VarChar, 3){ Value = message.Length },
                        new SqlParameter("@DataType", SqlDbType.VarChar, 2){ Value = message.DataType },
                        new SqlParameter("@StartIndex", SqlDbType.Int){ Value = message.StartIndex },
                        new SqlParameter("@EndIndex", SqlDbType.Int){ Value = message.EndIndex },
                        new SqlParameter("@Mandatory", SqlDbType.VarChar, 3){ Value = message.Mandatory },
                        new SqlParameter("@Description", SqlDbType.VarChar, 200){ Value = message.Description },
                        new SqlParameter("@DefaultValue", SqlDbType.VarChar, 50){ Value = message.DefaultValue },
                        new SqlParameter("@Remark", SqlDbType.NVarChar, 200){ Value = message.Remark }
                    };

                SQLSingleton.Instance.RunStoreProcedure(SpName, param, out oMessage);
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
        }

        private IEnumerable<MBaseMessageTypeModel> ExecuteStoreProcedure(string messageType, string tranCode = null)
        {
            List<MBaseMessageTypeModel> mBaseMessages = new List<MBaseMessageTypeModel>();
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
                WriteLog(oMessage);
            }

            return mBaseMessages;
        }
        private void SetMBaseMessageValue(DataTable dt, ref List<MBaseMessageTypeModel> mBaseMessages)
        {
            foreach (DataRow row in dt.Rows)
            {
                mBaseMessages.Add(new MBaseMessageTypeModel
                {
                    MessageType = row[nameof(MBaseMessageTypeModel.MessageType)].ToString(),
                    TranCode = row[nameof(MBaseMessageTypeModel.TranCode)].ToString(),
                    Seq = int.Parse(row[nameof(MBaseMessageTypeModel.Seq)].ToString()),
                    FieldName = row[nameof(MBaseMessageTypeModel.FieldName)].ToString(),
                    Length = row[nameof(MBaseMessageTypeModel.Length)].ToString(),
                    DataType = row[nameof(MBaseMessageTypeModel.DataType)].ToString(),
                    StartIndex = int.Parse(row[nameof(MBaseMessageTypeModel.StartIndex)].ToString()),
                    EndIndex = int.Parse(row[nameof(MBaseMessageTypeModel.EndIndex)].ToString()),
                    Mandatory = row[nameof(MBaseMessageTypeModel.Mandatory)].ToString(),
                    Description = row[nameof(MBaseMessageTypeModel.Description)].ToString(),
                    DefaultValue = row[nameof(MBaseMessageTypeModel.DefaultValue)].ToString(),
                    Remark = row[nameof(MBaseMessageTypeModel.Remark)].ToString()
                });
            }
        }

        private void WriteLog(string message)
        {
            Logging.WriteLog(message);
        }
    }
}