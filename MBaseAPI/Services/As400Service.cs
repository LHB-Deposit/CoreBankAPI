using iSeriesDataAccess;
using MBaseAccess.Entity;
using MBaseAPI.Interfaces;
using MBaseAPI.Models;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MBaseAPI.Services
{
    public class As400Service : IAs400Service
    {
        private string SQL;

        public As400Service()
        {

        }
        public IEnumerable<MessageTypeModel> ExecuteGetMessage(string sql)
        {
            List<MessageTypeModel> parameters = new List<MessageTypeModel>();
            try
            {
                AS400Singleton.Instance.ExecuteSql(sql, out DataTable dt, out string Message);
                foreach (DataRow row in dt.Rows)
                {
                    parameters.Add(new MessageTypeModel
                    {
                        MessageType = row["INPUTR"].ToString(),
                        TranCode = row["MTRAN"].ToString(),
                        Seq = int.Parse(row["FISEQ"].ToString()),
                        FieldName = row["FINAME"].ToString(),
                        Length = row["FILENB"].ToString(),
                        DataType = row["FITYPE"].ToString(),
                        StartIndex = int.Parse(row["FISTPO"].ToString()),
                        EndIndex = 0,
                        Mandatory = "",
                        Description = row["FIDESC"].ToString(),
                        DefaultValue = "",
                        Remark = ""
                    });
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
            return parameters;
        }
        public IEnumerable<MessageTypeModel> GetMBaseHeaderMessages(string tranCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageTypeModel> GetMBaseMessages(MBaseParameterModel parameterModel)
        {
            if (string.IsNullOrEmpty(parameterModel.TranCode))
            {
                SQL = $@"SELECT * FROM LHBDDATSMB.MBP003 WHERE INPUTR = '{ parameterModel.MessageType }' ORDER BY FISEQ ASC";
            }
            else
            {
                SQL = $@"SELECT * FROM LHBDDATSMB.MBP003 WHERE MTRAN = { parameterModel.TranCode } AND INPUTR = '{ parameterModel.MessageType }' ORDER BY FISEQ ASC";
            }
            
            return ExecuteGetMessage(SQL);
        }

        public IEnumerable<MessageTypeModel> GetMBaseResponseMessages(string tranCode)
        {
            throw new NotImplementedException();
        }
    }
}