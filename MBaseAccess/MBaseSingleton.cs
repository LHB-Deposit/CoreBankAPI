using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

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

        public CIFLevelResponse CIFCreation(CIFLevel cif, string terminalId, string referenceNumber, string clientDate, string clientTime)
        {


            return new CIFLevelResponse 
            { 
                CustomerNumber = "",
            };
        }
    }
}
