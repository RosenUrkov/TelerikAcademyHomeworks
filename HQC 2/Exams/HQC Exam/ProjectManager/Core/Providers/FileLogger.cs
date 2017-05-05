namespace ProjectManager.Core.Providers
{
    using Contracts;
    using log4net;

    public class FileLogger : IFileLogger
    {
        private static ILog logger;

        static FileLogger()
        {
            logger = LogManager.GetLogger(typeof(FileLogger));
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }
}
