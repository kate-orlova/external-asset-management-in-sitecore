namespace Foundation.AssetManagement.Configuration
{
    public static class ConfigSettings
    {
        public static string Host => GetSetting(Constants.AppSettings.Host);
        public static string SearchUrl => GetSetting(Constants.AppSettings.SearchUrl);
        public static string ContentType => GetSetting(Constants.AppSettings.ContentType);
        public static string AccessKey => GetSetting(Constants.AppSettings.AccessKey);
        public static string SecretKey => GetSetting(Constants.AppSettings.SecretKey);
        public static string RegionName => GetSetting(Constants.AppSettings.RegionName);
        public static string ServiceName => GetSetting(Constants.AppSettings.ServiceName);
        public static string SignedHeaders => GetSetting(Constants.AppSettings.SignedHeaders);
        public static string Algorithm => GetSetting(Constants.AppSettings.Algorithm);

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