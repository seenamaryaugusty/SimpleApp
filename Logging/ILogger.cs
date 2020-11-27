using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public enum LogType
    {
        File,
        All
    }
    public interface ILogger
    {
        void Log(string message);
    }
}
