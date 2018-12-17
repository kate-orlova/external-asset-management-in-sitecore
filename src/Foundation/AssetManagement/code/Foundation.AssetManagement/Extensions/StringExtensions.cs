using Sitecore.StringExtensions;

namespace Foundation.AssetManagement.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string target)
        {
            int result = 0;
            if (!target.IsNullOrEmpty())
                int.TryParse(target, out result);
            return result;
        }
    }
}