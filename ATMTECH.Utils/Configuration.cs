using System.Configuration;

namespace ATMTECH.Utils
{
    public static class Configuration
    {
        public static string GetConfigurationKey(string key)
        {
            string config = ConfigurationManager.AppSettings.Get(key);
            if (config == null && key == "ConnectionString")
            {
               config = ConfigurationManager.ConnectionStrings[1].ToString();
            }
            return config;
        }

        public static void SetConfigurationKey(string key, string value)
        {
            ConfigurationManager.AppSettings.Set(key, value);
        }
    }
}
