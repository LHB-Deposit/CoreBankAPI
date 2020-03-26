using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
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

                Message = current_date + ":" + current_time.PadRight(20, ' ') + Message;
                DirectoryInfo dir = new DirectoryInfo(logFolder);
                if (!dir.Exists) dir.Create();

                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine(Message);
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }
    }
}
