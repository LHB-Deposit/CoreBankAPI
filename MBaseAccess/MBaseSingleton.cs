using JonSkeet.Ebcdic;
using MBaseAccess.Entity;
using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private string ServerHost
        {
            get
            {
                try { return ConfigurationManager.AppSettings["ServerIP"].ToString(); }
                catch (Exception ex) { throw new Exception("Please enter server host (" + ex.Message + ")"); }
            }
        }
        private int ServerPort
        {
            get
            {
                try { return Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"].ToString()); }
                catch (Exception ex) { throw new Exception("Please enter server port (" + ex.Message + ")"); }
            }
        }
        private int HeaderMessageLength = 666;

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


        public CIFAccountResponse CIFCreation(CIFAccount cif, MBaseMessage mBaseMessage, string terminalId, string referenceNumber, DateTime clientDateTime)
        {
            CIFAccountResponse responseModel = new CIFAccountResponse();
            if (mBaseMessage.Header == null) return null;

            try
            {
                TcpClient clientSocket = new TcpClient
                {
                    ReceiveBufferSize = HeaderMessageLength + mBaseMessage.Header.InputLength + mBaseMessage.Header.ResponseLength,
                    ReceiveTimeout = ReceiveTimeout,
                    SendTimeout = SendTimeout
                };

                if (!clientSocket.Connected)
                    clientSocket.Connect(ServerHost, ServerPort);

                if (clientSocket.Connected)
                {
                    NetworkStream serverStream = clientSocket.GetStream();

                    byte[] headParameter = CreateInputMessage(mBaseMessage, terminalId, referenceNumber, cif.CFBRNN, clientDateTime.ToString("ddMMyyyy"), clientDateTime.ToString("HHmmss"));

                    serverStream.Write(headParameter, 0, headParameter.Length);
                    serverStream.Flush();

                    int rsMsgLength = HeaderMessageLength + mBaseMessage.Header.InputLength + mBaseMessage.Header.ResponseLength;

                    byte[] outStream = new byte[rsMsgLength];
                    serverStream.Read(outStream, 0, clientSocket.ReceiveBufferSize);

                    bool isEmptyReturn = false;
                    string empty = outStream.ToString();

                    if (string.IsNullOrEmpty(empty.Trim())) isEmptyReturn = true;
                    if (!isEmptyReturn)
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
                            Logging.WriteLog($"Create CIF Detail Error : { strCode } { strDesc }");
                            return null;
                        }

                        foreach (var response in mBaseMessage.ResponseMessages)
                        {
                            int startIndex = response.StartIndex - 1;
                            int endIndex = response.EndIndex - 1;

                            startIndex = (HeaderMessageLength) + startIndex;
                            endIndex = (HeaderMessageLength) + endIndex;

                            DataType dType;
                            switch (response.DataType)
                            {
                                case "B":
                                    dType = DataType.B;
                                    break;
                                case "S":
                                    dType = DataType.S;
                                    break;
                                case "P":
                                    dType = DataType.P;
                                    break;
                                default:
                                    dType = DataType.A;
                                    break;
                            }
                            switch (response.FieldName)
                            {
                                case nameof(CIFAccountResponse.CFCIFN):
                                    responseModel.CFCIFN = ConvertDataResponse(outStream, startIndex, endIndex, dType);
                                    break;
                                case nameof(CIFAccountResponse.ACCTNO):
                                    responseModel.ACCTNO = ConvertDataResponse(outStream, startIndex, endIndex, dType);
                                    break;
                                case nameof(CIFAccountResponse.ACTYPE):
                                    responseModel.ACTYPE = ConvertDataResponse(outStream, startIndex, endIndex, dType);
                                    break;
                            }
                            
                        }
                    }
                }
                else
                {
                    Logging.WriteLog($"Cannot connect to { ServerHost }");
                    return null;
                }

                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }

            return responseModel;
        }


        private byte[] CreateInputMessage(MBaseMessage mBaseMessage, string terminalId, string referenceNo, string branchNo, string clientDate, string clientTime)
        {
            //string as400UserId = "LHD8899201";

            int rqMsgLength = HeaderMessageLength + mBaseMessage.Header.InputLength;
            byte[] oByte = new byte[rqMsgLength];

            foreach (var header in mBaseMessage.HeaderMessages)
            {
                SetDataBytePosition( ref oByte, header);
            }

            foreach (var input in mBaseMessage.InputMessages)
            {
                SetDataBytePosition(ref oByte, input);
            }

            return oByte;
        }

        private void SetDataBytePosition(ref byte[] oByte, MBaseMessageType input)
        {
            int idx, pos, start_idx, end_idx;
            string default_val;

            start_idx = input.StartIndex;
            end_idx = input.EndIndex;
            default_val = input.DefaultValue;

            DataType dType;
            switch (input.DataType.ToUpper())
            {
                case "B":
                    dType = DataType.B;
                    break;
                case "P":
                    dType = DataType.P;
                    default_val = SetDefaultValue(default_val);
                    break;
                case "S":
                    dType = DataType.S;
                    default_val = SetDefaultValue(default_val);
                    break;
                default:
                    dType = DataType.A;
                    break;
            }

            byte[] data = ConvertData(default_val, start_idx, end_idx, dType);

            idx = 0;
            for (pos = start_idx - 1; pos < end_idx; pos++)
            {
                oByte[pos] = data[idx];
                idx++;
            }
        }
        private string SetDefaultValue(string default_val)
        {
            if (string.IsNullOrEmpty(default_val))
            {
                default_val = "0";
            }

            return default_val;
        }
        private byte[] ConvertData(string data, int startIndex, int endIndex, DataType type)
        {
            int len = (endIndex - startIndex) + 1;
            if ((type == DataType.A) || (type == DataType.S))
            {//if convert to EBCDIC or Zoned Decimal
                Encoding eC = EbcdicEncoding.GetEncoding(20838);//"EBCDIC-US"

                if (data.Length < len)
                    data = data.PadRight(len, data == "0" ? '0' : ' ');

                return eC.GetBytes(data);
            }
            else if (type == DataType.B)
            {//if convert to Binary 
             //if (data.Length < len)
             //data = data.PadLeft(len, data == "0" ? '0' : ' ');
                int i = Convert.ToInt32(data);
                byte[] pB = System.BitConverter.GetBytes(i);
                Array.Reverse(pB);
                return pB;
                //return  System.BitConverter.GetBytes(i).Reverse().ToArray(); ;// Encoding.ASCII.GetBytes(data);
            }
            else
            {//if convert to packed decimal or other else
             //if (data.Length < len)
             //    data = data.PadLeft(len, '0');

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
                            //returnValue[i] = 0x0d;
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

                Encoding eC = EbcdicEncoding.GetEncoding(20838);//"EBCDIC-US"
                return eC.GetString(data);
            }
            else if (type == DataType.B)
            {
                Array.Reverse(data);
                //return BitConverter.ToString(data.Reverse().ToArray());
                return BitConverter.ToString(data);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                //data[data.Length - 1] = (byte)((Convert.ToInt32(data[data.Length - 1])) >> 4);
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
                //return BitConverter.ToString(data.Reverse().ToArray());
                return BitConverter.ToString(data);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                //data[data.Length - 1] = (byte)((Convert.ToInt32(data[data.Length - 1])) >> 4);
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
