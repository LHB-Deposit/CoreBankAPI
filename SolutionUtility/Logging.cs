using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class Logging
    {
        public static void WriteLog(string Message)
        {
            try
            {
                string appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                string logFolder = Path.Combine(appRootPath, "Log");
                string current_date = DateTime.Now.ToString("yyyyMMdd");
                string current_time = DateTime.Now.ToString("HH:mm:ss");
                string currentFile = "log" + current_date + ".txt";

                string logFile = Path.Combine(logFolder, currentFile);

                Message = current_date + "|" + current_time.PadRight(2, ' ') + "> " + Message;
                DirectoryInfo dir = new DirectoryInfo(logFolder);
                if (!dir.Exists) dir.Create();

                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine(Message);
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }

        public static void WriteLog<T>(T obj)
        {
            Dictionary<string, object> dictLog = new Dictionary<string, object>();
            
            var objProperties = obj.GetType().GetProperties();
            foreach (var prop in objProperties)
            {
                dictLog.Add(prop.Name, prop.GetValue(obj));
            }
            string logTitle = string.Empty;
            if (obj.GetType().Name.Contains("Request")) logTitle = "Request";
            else if (obj.GetType().Name.Contains("Response")) logTitle = "Response";

            WriteLog($"{logTitle}: {string.Join(", ", dictLog)}");
        }
    }
}
