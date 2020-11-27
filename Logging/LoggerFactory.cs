using System.Collections.Generic;

namespace Logging
{
    public class LoggerFactory
    {
        private static Dictionary<LogType, ILogger> loggers = new Dictionary<LogType, ILogger>();

        public static ILogger GetLogger(LogType logType)
        {
            if (loggers.ContainsKey(logType))
                return loggers[logType];
            else
            {
                loggers.Add(logType, new FileLogger());
                return loggers[logType];
            }
        }
    }
}
