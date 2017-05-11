namespace DevelopmentTools
{
    using System;
    using System.Configuration;
    using log4net;

    /// <summary>
    /// The class that holds the main method
    /// </summary>
    public class Startup
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Startup));

        /// <summary>
        /// Starting point of the application
        /// </summary>
        public static void Main()
        {
            var mySetting = ConfigurationManager.AppSettings["mySetting"]; 
            
            Logger.Error(mySetting);            
        }
    }
}
