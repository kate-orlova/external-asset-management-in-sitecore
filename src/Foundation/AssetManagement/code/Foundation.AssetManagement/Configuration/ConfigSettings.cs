namespace Foundation.AssetManagement.Configuration
{
    public static class ConfigSettings
    {

        static string GetSetting(string settingName, string defaultValue = null)
        {
            var settingValue = Sitecore.Configuration.Settings.GetSetting(settingName);

            return settingValue;
        }
    }
}