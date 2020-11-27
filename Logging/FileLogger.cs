using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class FileLogger:ILogger
    {
        public string logFilePath = @"c:\SimpleAppLog.txt";
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFilePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
