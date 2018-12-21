namespace Foundation.AssetManagement.Configuration
{
    public static class ConfigSettings
    {
        public static string Host => GetSetting(Constants.AppSettings.Host);

        static string GetSetting(string settingName, string defaultValue = null)
        {
            var settingValue = Sitecore.Configuration.Settings.GetSetting(settingName);

            if (string.IsNullOrEmpty(settingValue))
            {
                settingValue = defaultValue;
            }

            return settingValue;
        }
        static int GetSetting(string settingName, int defaultValue)
        {
            return Sitecore.Configuration.Settings.GetIntSetting(settingName, defaultValue);
        }
        static double GetSetting(string settingName, double defaultValue)
        {
            return Sitecore.Configuration.Settings.GetDoubleSetting(settingName, defaultValue);
        }
        static bool GetSetting(string settingName, bool defaultValue)
        {
            return Sitecore.Configuration.Settings.GetBoolSetting(settingName, defaultValue);
        }
    }
}