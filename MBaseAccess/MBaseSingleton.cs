using JonSkeet.Ebcdic;
using MBaseAccess.Entity;
using SolutionUtility;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess
{
    public sealed class MBaseSingleton
    {
        private int ReceiveBufferSize
        {
            get { return 1519; }
        }
        private int ReceiveTimeout
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["RecieveTimeOut"].ToString());
                }
                catch
                {
                    return 10000;
                }
            }
        }
        private int SendTimeout
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["SendTimeOut"].ToString());
                }
                catch
                {
                    return 10000;
                }
            }
        }
        public string ServerHost
        {
            get
            {
                try { return ConfigurationManager.AppSettings["ServerIP"].ToString(); }
                catch (Exception ex) { throw new Exception("Please enter server host (" + ex.Message + ")"); }
            }
        }
        public int ServerPort
        {
            get
            {
                try { return Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"].ToString()); }
                catch (Exception ex) { throw new Exception("Please enter server port (" + ex.Message + ")"); }
            }
        }
        public int HeaderMessageLength = 666;

        public string Message { get; set; } = string.Empty;

        private MBaseSingleton() { }
        private static MBaseSingleton mbase = null;

        public static MBaseSingleton Instance
        {
            get
            {
                if(mbase == null)
                {
                    mbase = new MBaseSingleton();
                }
                return mbase;
            }
        }

        public VerifyCitizenIDResponse VerifyCitizenID(MBaseMessage message)
        {
            return GetMessageResponse(message, new VerifyCitizenIDResponse());
        }

        public CIFAccountResponse CIFCreation(MBaseMessage message)
        {
            return GetMessageResponse(message, new CIFAccountResponse());
        }

        private T GetMessageResponse<T>(MBaseMessage message, T resResult)
        {
            if (message.HeaderTransaction == null) return resResult;

            int inputLength = Convert.ToInt16(message.HeaderTransaction.InputLength);
            int responseLength = Convert.ToInt16(message.HeaderTransaction.ResponseLength);
            TcpClient clientSocket = new TcpClient
            {
                ReceiveBufferSize = HeaderMessageLength + inputLength + responseLength,
                ReceiveTimeout = ReceiveTimeout,
                SendTimeout = SendTimeout
            };

            try
            {
                if (!clientSocket.Connected)
                    clientSocket.Connect(ServerHost, ServerPort);

                if (clientSocket.Connected)
                {
                    #region Header Stream
                    Logging.WriteLog("Connect [Host:" + ServerHost + "] [Port:" + ServerPort + "]");
                    Logging.WriteLog("Connected");

                    NetworkStream serverStream = clientSocket.GetStream();

                    Logging.WriteLog("Create Input Message");

                    byte[] headParameter = CreateInputMessage(message);

                    Logging.WriteLog("Write Stream [Length:" + headParameter.Length + "]");
                    serverStream.Write(headParameter, 0, headParameter.Length);
                    serverStream.Flush();

                    int rsMsgLength = HeaderMessageLength + inputLength + responseLength;
                    Logging.WriteLog("Read Stream [Length:" + rsMsgLength.ToString() + "]");
                    #endregion

                    byte[] outStream = new byte[rsMsgLength];
                    serverStream.Read(outStream, 0, (int)clientSocket.ReceiveBufferSize);

                    Dictionary<string, string> dictResult = new Dictionary<string, string>();
                    bool inputMessageValid = CheckInputMessageValid(ref outStream, ref dictResult);
                    if (inputMessageValid)
                    {
                        Logging.WriteLog("Write Response");
                        foreach (var res in message.ResponseMessages)
                        {
                            #region Do Somthing
                            int startIndex = Convert.ToInt32(res.StartIndex) - 1;
                            int endIndex = Convert.ToInt32(res.EndIndex) - 1;

                            string data_type = res.DataType;

                            startIndex = (HeaderMessageLength) + startIndex;
                            endIndex = (HeaderMessageLength) + endIndex;

                            DataType dType = DataType.A;

                            if (data_type == "B")
                                dType = DataType.B;
                            else if (data_type == "A")
                                dType = DataType.A;
                            else if (data_type == "P")
                                dType = DataType.P;
                            else //if (dr.ToString() == "S")
                                dType = DataType.S;
                            #endregion
                            dictResult.Add(res.FieldName, ConvertDataResponse(outStream, startIndex, endIndex, dType));
                        }
                        Logging.WriteLog($"Response: " + string.Join(", ", dictResult));
                        switch (resResult.GetType().Name)
                        {
                            case nameof(CIFAccountResponse):
                                var objCIFAccResponse = (CIFAccountResponse)Convert.ChangeType(resResult, typeof(CIFAccountResponse));
                                objCIFAccResponse.CFCIFN = dictResult[nameof(CIFAccountResponse.CFCIFN)];
                                objCIFAccResponse.ACCTNO = dictResult[nameof(CIFAccountResponse.ACCTNO)];
                                objCIFAccResponse.ACTYPE = dictResult[nameof(CIFAccountResponse.ACTYPE)];
                                resResult = (T)Convert.ChangeType(objCIFAccResponse, typeof(T));
                                break;
                            case nameof(VerifyCitizenIDResponse):
                                var objVerifyResponse = (VerifyCitizenIDResponse)Convert.ChangeType(resResult, typeof(VerifyCitizenIDResponse));
                                objVerifyResponse.CFCIFN = dictResult[nameof(VerifyCitizenIDResponse.CFCIFN)];
                                objVerifyResponse.CFCIFT = dictResult[nameof(VerifyCitizenIDResponse.CFCIFT)];
                                objVerifyResponse.CFNA1 = dictResult[nameof(VerifyCitizenIDResponse.CFNA1)];
                                objVerifyResponse.CFNA1A = dictResult[nameof(VerifyCitizenIDResponse.CFNA1A)];
                                objVerifyResponse.CFSSNO = dictResult[nameof(VerifyCitizenIDResponse.CFSSNO)];
                                objVerifyResponse.CFSSCD = dictResult[nameof(VerifyCitizenIDResponse.CFSSCD)];
                                objVerifyResponse.CFCIDT = dictResult[nameof(VerifyCitizenIDResponse.CFCIDT)];
                                objVerifyResponse.CFNAE = dictResult[nameof(VerifyCitizenIDResponse.CFNAE)];
                                resResult = (T)Convert.ChangeType(objVerifyResponse, typeof(T));
                                break;
                        }
                    }
                    else
                    {
                        // Todo Error Response
                        Logging.WriteLog($"Response: " + string.Join(", ", dictResult));
                    }

                    
                }
                else
                {
                    Logging.WriteLog($"Cannot connect to { ServerHost }");
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog($"{ex.Message}: {ex.StackTrace}");
            }
            finally
            {
                if (clientSocket != null) clientSocket.Close();
            }

            return resResult;
        }

        private bool CheckInputMessageValid(ref byte[] outStream, ref Dictionary<string, string> strError)
        {
            bool isValid = false;

            try
            {
                if (!string.IsNullOrEmpty(outStream.ToString().Trim()))
                {
                    //Check error from server
                    byte[] errCode = new byte[7];
                    byte[] errDesc = new byte[50];

                    int i;
                    int index = 0;

                    //get error code
                    for (i = 341; i <= 347; i++)
                    {
                        errCode[index] = outStream[i];
                        index++;
                    }

                    index = 0;
                    //get error desc
                    for (i = 348; i <= 397; i++)
                    {
                        errDesc[index] = outStream[i];
                        index++;
                    }

                    string strCode = ConvertDataResponseCheckError(errCode, 0, 6, DataType.A);
                    string strDesc = ConvertDataResponseCheckError(errDesc, 0, 49, DataType.A);

                    if (!string.IsNullOrEmpty(strDesc.Trim()))
                    {
                        Logging.WriteLog("Error : " + strCode + " " + strDesc);
                        strError.Add(strCode, strDesc);
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isValid;
        }

        private string ConvertDataResponseCheckError(byte[] allData, int startIndex, int endIndex, DataType type)
        {
            int len = (endIndex - startIndex) + 1;
            byte[] data = new byte[len];

            for (int i = 0; i < data.Length; i++)
                data[i] = allData[startIndex + i];

            if ((type == DataType.A) || (type == DataType.S))
            {
                if (type == DataType.A)
                {
                    bool isValid = false;
                    foreach (byte b in data)
                    {
                        if (b != 0)
                        {
                            isValid = true;
                            break;
                        }
                    }

                    if (!isValid)
                        return "Unidentify error.";
                }

                Encoding eC = JonSkeet.Ebcdic.EbcdicEncoding.GetEncoding(20838);//"EBCDIC-US"
                return eC.GetString(data);
            }
            else if (type == DataType.B)
            {
                Array.Reverse(data);
                return BitConverter.ToString(data);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                    sb.Append(b.ToString("X2"));

                string hexString = sb.ToString();
                string signString = hexString.Substring(hexString.Length - 1);
                hexString = hexString.Substring(0, hexString.Length - 1);
                if (signString.ToUpper() == "D")
                {
                    hexString = "-" + hexString;
                }
                sb = null;

                return hexString;
            }
        }

        private byte[] CreateInputMessage(MBaseMessage message)
        {
            // Test
            //AS400UserId = "LHD8899201";
            try
            {
                int i, idx, pos, StartIndex, EndIndex;
                string DefaultValue;

                string transactionCode = message.HeaderTransaction.MBaseTranCode;
                string scenarioNumber = message.HeaderTransaction.ScenarioNumber;
                string actionMode = message.HeaderTransaction.ActionMode;
                string transactionMode = message.HeaderTransaction.TransactionMode;
                string numberOfRetrieve = message.HeaderTransaction.NoOfRecToRetrieve;
                string inputLength = message.HeaderTransaction.InputLength.ToString();
                string responseLength = message.HeaderTransaction.ResponseLength.ToString();

                int rqMsgLength = HeaderMessageLength + Convert.ToInt16(inputLength);

                Logging.WriteLog("Request Msg Length:" + rqMsgLength.ToString());
                byte[] oByte = new byte[rqMsgLength];

                #region Header

                foreach (var header in message.HeaderMessages)
                {
                    StartIndex = Convert.ToInt16(header.StartIndex.ToString());
                    EndIndex = Convert.ToInt16(header.EndIndex.ToString());
                    DefaultValue = header.DefaultValue;

                    DataType dType = DataType.A;
                    switch (header.DataType.ToUpper())
                    {
                        case "B":
                            dType = DataType.B;
                            break;

                        case "P":
                            dType = DataType.P;
                            if (DefaultValue == string.Empty)
                                DefaultValue = "0";
                            break;

                        case "S":
                            dType = DataType.S;
                            if (DefaultValue == string.Empty)
                                DefaultValue = "0";
                            break;
                    }

                    byte[] data = ConvertData(DefaultValue, StartIndex, EndIndex, dType);

                    idx = 0;
                    for (pos = StartIndex - 1; pos < EndIndex; pos++)
                    {
                        oByte[pos] = data[idx];
                        idx++;
                    }
                }
                #endregion

                foreach (var input in message.InputMessages)
                {
                    StartIndex = Convert.ToInt16(input.StartIndex.ToString()) + HeaderMessageLength;
                    EndIndex = Convert.ToInt16(input.EndIndex.ToString()) + HeaderMessageLength;
                    DefaultValue = input.DefaultValue;

                    DataType dType = DataType.A;
                    switch (input.DataType.ToUpper())
                    {
                        case "B":
                            dType = DataType.B;
                            break;

                        case "P":
                            dType = DataType.P;
                            if (DefaultValue == "")
                                DefaultValue = "0";
                            break;

                        case "S":
                            dType = DataType.S;
                            if (DefaultValue == "")
                                DefaultValue = "0";
                            break;
                    }

                    byte[] data = ConvertData(DefaultValue, StartIndex, EndIndex, dType);

                    idx = 0;
                    for (pos = StartIndex - 1; pos < EndIndex; pos++)
                    {
                        oByte[pos] = data[idx];
                        idx++;
                    }
                }

                return oByte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] ConvertData(string data, int startIndex, int endIndex, DataType type)
        {
            int len = (endIndex - startIndex) + 1;

            if ((type == DataType.A) || (type == DataType.S))
            {//if convert to EBCDIC or Zoned Decimal
                Encoding eC = JonSkeet.Ebcdic.EbcdicEncoding.GetEncoding(20838);//"EBCDIC-US"

                if (data.Length < len)
                    data = data.PadRight(len, data == "0" ? '0' : ' ');

                return eC.GetBytes(data);
            }
            else if (type == DataType.B)
            {//if convert to Binary 
                int i = Convert.ToInt32(data);
                byte[] pB = System.BitConverter.GetBytes(i);
                Array.Reverse(pB);
                return pB;
            }
            else
            {//if convert to packed decimal or other else

                Stack<byte> comp3 = new Stack<byte>();
                int value = Convert.ToInt32(data);

                byte currentByte;
                if (value < 0)
                {
                    currentByte = 0x0d;
                    value = -value;
                }
                else
                {
                    currentByte = 0x0f;
                }

                bool byteComplete = false;
                while (value != 0)
                {
                    if (byteComplete)
                        currentByte = (byte)(value % 10);
                    else
                        currentByte |= (byte)((value % 10) << 4);
                    value /= 10;
                    byteComplete = !byteComplete;
                    if (byteComplete)
                        comp3.Push(currentByte);
                }
                if (!byteComplete)
                    comp3.Push(currentByte);

                byte[] returnValue = new byte[len];
                if (comp3.ToArray().Length < len)
                {
                    int index = 0;
                    for (int i = 0; i < len; i++)
                    {
                        if (i < len - comp3.ToArray().Length)
                        {
                            returnValue[i] = 0000;
                        }
                        else
                        {
                            returnValue[i] = comp3.ToArray()[index];
                            index++;
                        }
                    }
                }
                else
                    returnValue = comp3.ToArray();

                return returnValue;
            }
        }

        private string ConvertDataResponse(byte[] allData, int startIndex, int endIndex, DataType type)
        {
            int len = (endIndex - startIndex) + 1;
            byte[] data = new byte[len];

            for (int i = 0; i < data.Length; i++)
                data[i] = allData[startIndex + i];

            if ((type == DataType.A) || (type == DataType.S))
            {
                if (type == DataType.A)
                {
                    bool isValid = false;
                    foreach (byte b in data)
                    {
                        if (b != 0)
                        {
                            isValid = true;
                            break;
                        }
                    }

                    if (!isValid)
                        return string.Empty;
                }
                Encoding eC = EbcdicEncoding.GetEncoding(20838);//"EBCDIC-US"
                return eC.GetString(data);
            }
            else if (type == DataType.B)
            {
                Array.Reverse(data);
                return BitConverter.ToString(data);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                    sb.Append(b.ToString("X2"));

                string hexString = sb.ToString();
                string signString = hexString.Substring(hexString.Length - 1);
                hexString = hexString.Substring(0, hexString.Length - 1);
                if (signString.ToUpper() == "D")
                {
                    hexString = "-" + hexString;
                }
                sb = null;

                return hexString;
            }
        }
    }

    public enum DataType
    {
        B, A, P, S
    }
}
