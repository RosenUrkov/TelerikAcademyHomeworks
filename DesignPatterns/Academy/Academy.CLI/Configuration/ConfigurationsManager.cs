using System;
using System.Configuration;

namespace Academy.Configuration
{
    public class ConfigurationsManager : IConfigurationsManager
    {
        public bool IsListingCommandsEnvironment()
        {
            return bool.Parse(ConfigurationManager.AppSettings["IsListingEnvironment"]);
        }
    }
}
