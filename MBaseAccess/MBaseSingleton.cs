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
        public VerifyCitizenResponse VerifyCitizenID(MBaseMessage message)
        {
            VerifyCitizenResponse response = new VerifyCitizenResponse();
            var resMessages = GetMessageResponse(message);
            foreach (var res in resMessages)
            {
                switch(res.Key.Trim())
                {
                    case nameof(VerifyCitizenResponse.CFCIFN):
                        response.CFCIFN = StringToDigit(res.Value);
                        break;
                    case nameof(VerifyCitizenResponse.CFCIFT):
                        response.CFCIFT = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFNA1):
                        response.CFNA1 = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFNA1A):
                        response.CFNA1A = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFSSNO):
                        response.CFSSNO = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFSSCD):
                        response.CFSSCD = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFCIDT):
                        response.CFCIDT = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFASN1):
                        response.CFASN1 = res.Value.Trim();
                        break;
                    case nameof(VerifyCitizenResponse.CFASN2):
                        response.CFASN2 = res.Value.Trim();
                        break;
                    default:
                        response.ErrorCode = res.Key;
                        response.ErrorDescription = res.Value;
                        break;
                }
            }
            return response;
        }
        public CIFAccountResponse CIFCreation(MBaseMessage message)
        {
            CIFAccountResponse response = new CIFAccountResponse();
            var resMessages = GetMessageResponse(message);
            foreach (var res in resMessages)
            {
                switch (res.Key.Trim())
                {
                    case nameof(CIFAccountResponse.CFCIFN):
                        response.CFCIFN = StringToDigit(res.Value);
                        break;
                    case nameof(CIFAccountResponse.CFACCTNO):
                        response.CFACCTNO = StringToDigit(res.Value);
                        break;
                    case nameof(CIFAccountResponse.CFACCTYP):
                        response.CFACCTYP = res.Value;
                        break;
                    default:
                        response.ErrorCode = res.Key;
                        response.ErrorDescription = res.Value;
                        break;
                }
            }
            return response;
        }
        public CIFAddressResponse CIFAddressCreation(MBaseMessage message)
        {
            CIFAddressResponse response = new CIFAddressResponse();
            var resMessages = GetMessageResponse(message);
            foreach (var res in resMessages)
            {
                switch (res.Key.Trim())
                {
                    case nameof(CIFAddressResponse.CFCIFN):
                        response.CFCIFN = StringToDigit(res.Value);
                        break;
                    case nameof(CIFAddressResponse.CFADSQ):
                        response.CFADSQ = StringToDigit(res.Value);
                        break;
                }
            }
            return response;
        }
        public KycCIFLevelResponse KycCIFLevelCreateMessage(MBaseMessage message)
        {
            KycCIFLevelResponse response = new KycCIFLevelResponse();
            var resMessages = GetMessageResponse(message);
            foreach (var res in resMessages)
            {
                switch (res.Key.Trim())
                {
                    case nameof(KycCIFLevelResponse.KCCIFN):
                        response.KCCIFN = StringToDigit(res.Value);
                        break;
                    case nameof(KycCIFLevelResponse.KCFRKL):
                        response.KCFRKL = res.Value;
                        break;
                    case nameof(KycCIFLevelResponse.KCRRKL):
                        response.KCRRKL = res.Value;
                        break;
                    case nameof(KycCIFLevelResponse.KCLRDT):
                        response.KCLRDT = res.Value;
                        break;
                    case nameof(KycCIFLevelResponse.KCNRDT):
                        response.KCNRDT = res.Value;
                        break;
                    case nameof(KycCIFLevelResponse.WDTEXT):
                        response.WDTEXT = res.Value;
                        break;
                }
            }
            return response;
        }
        public KycAccountLevelResponse KycAccountLevelCreateMessage(MBaseMessage message)
        {
            KycAccountLevelResponse response = new KycAccountLevelResponse();
            var resMessages = GetMessageResponse(message);
            foreach (var res in resMessages)
            {
                switch (res.Key.Trim())
                {
                    case nameof(KycAccountLevelResponse.KCATYP):
                        response.KCATYP = res.Value;
                        break;
                    case nameof(KycAccountLevelResponse.KCACCN):
                        response.KCACCN = StringToDigit(res.Value);
                        break;
                    case nameof(KycAccountLevelResponse.DEPPURINV):
                        response.DEPPURINV = res.Value;
                        break;
                    case nameof(KycAccountLevelResponse.DEPSRCINV):
                        response.DEPSRCINV = res.Value;
                        break;
                    case nameof(KycAccountLevelResponse.KCSCOU):
                        response.KCSCOU = res.Value;
                        break;
                    case nameof(KycAccountLevelResponse.KCOPAM):
                        response.KCOPAM = StringToDigit(res.Value);
                        break;
                }
            }
            return response;
        }

        private string StringToDigit(string value)
        {
            if (!string.IsNullOrEmpty(value)) return long.Parse(value).ToString();
            else return value;
        }
        private Dictionary<string, string> GetMessageResponse(MBaseMessage message)
        {
            Dictionary<string, string> dictResult = new Dictionary<string, string>();
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
                    Logging.WriteLog("Connect [Host:" + ServerHost + "] [Port:" + ServerPort + "]");
                    Logging.WriteLog("Connected");

                    NetworkStream serverStream = clientSocket.GetStream();

                    Logging.WriteLog("Create Input Message TranCode:" + message.HeaderTransaction.MBaseTranCode);

                    byte[] headParameter = CreateInputMessage(message);

                    Logging.WriteLog("Write Stream [Length:" + headParameter.Length + "]");
                    serverStream.Write(headParameter, 0, headParameter.Length);
                    serverStream.Flush();

                    int rsMsgLength = HeaderMessageLength + inputLength + responseLength;
                    Logging.WriteLog("Read Stream [Length:" + rsMsgLength.ToString() + "]");

                    byte[] outStream = new byte[rsMsgLength];
                    serverStream.Read(outStream, 0, (int)clientSocket.ReceiveBufferSize);
                    
                    bool inputMessageValid = CheckInputMessageValid(ref outStream, ref dictResult);
                    if (inputMessageValid)
                    {
                        Logging.WriteLog("Write Response");
                        foreach (var res in message.ResponseMessages)
                        {
                            int startIndex = Convert.ToInt32(res.StartIndex) - 1;
                            int endIndex = Convert.ToInt32(res.EndIndex) - 1;
                            startIndex = (HeaderMessageLength) + startIndex;
                            endIndex = (HeaderMessageLength) + endIndex;

                            string data_type = res.DataType;
                            DataType dType = DataType.A;
                            if (data_type == nameof(DataType.B))
                                dType = DataType.B;
                            else if (data_type == nameof(DataType.A))
                                dType = DataType.A;
                            else if (data_type == nameof(DataType.P))
                                dType = DataType.P;
                            else //if (dr.ToString() == "S")
                                dType = DataType.S;

                            dictResult.Add(res.FieldName.Trim(), ConvertDataResponse(outStream, startIndex, endIndex, dType).Trim());
                        }
                    }

                    if(dictResult.Count > 0) Logging.WriteLog($"Response: " + string.Join(", ", dictResult));
                }
                else
                {
                    Logging.WriteLog($"Cannot connect to { ServerHost }");
                }
            }
            catch (Exception ex)
            {
                dictResult.Add("Exception", ex.Message);
                Logging.WriteLog($"{ex.Message}: {ex.StackTrace}");
            }
            finally
            {
                if (clientSocket != null) clientSocket.Close();
            }

            return dictResult;
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

                    string strCode = ConvertDataResponse(errCode, 0, 6, DataType.A);
                    string strDesc = ConvertDataResponse(errDesc, 0, 49, DataType.A);

                    if (!string.IsNullOrEmpty(strDesc.Trim()))
                    {
                        Logging.WriteLog("Reject Code: " + strCode + " " + strDesc);
                        strError.Add(strCode.Trim(), strDesc.Trim());
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
        private byte[] CreateInputMessage(MBaseMessage message)
        {
            // Test
            //AS400UserId = "LHD8899201";
            byte[] oByte = new byte[0];
            try
            {
                int idx, pos, StartIndex, EndIndex;
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
                oByte = new byte[rqMsgLength];

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

               
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message + ":" + ex.StackTrace);
            }
            return oByte;
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
                return eC.GetString(data).Replace("\u0000", string.Empty);
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
