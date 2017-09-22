using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Common.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly ILog logger;

        public FileLogger()
        {
            this.logger = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Log(string message)
        {
            this.logger.Error(message);
        }
    }
}