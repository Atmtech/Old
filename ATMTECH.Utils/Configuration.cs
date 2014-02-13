using System.Configuration;

namespace ATMTECH.Utils
{
    public static class Configuration
    {
        public static string GetConfigurationKey(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public static void SetConfigurationKey(string key, string value)
        {
            ConfigurationManager.AppSettings.Set(key, value);
        }
    }
}
