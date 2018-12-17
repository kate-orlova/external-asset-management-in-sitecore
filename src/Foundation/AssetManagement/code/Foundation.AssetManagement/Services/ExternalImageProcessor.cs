using Foundation.AssetManagement.Interfaces;
using Sitecore.StringExtensions;

namespace Foundation.AssetManagement.Services
{
    public class ExternalImageProcessor : IExternalImageProcessor
    {
        public string Resize(string url, int width, string additionalParameters)
        {
            if (url.IsNullOrEmpty())
            {
                return null;
            }

            var separator = url.Contains("?") ? "&" : "?";
            if (additionalParameters.IsNullOrEmpty())
            {
                additionalParameters = additionalParameters.Trim('&', '?');

                var sizeIsPredefined = false;
                int sourceWidth = 0, sourceHeight = 0;

                return $"{url}{separator}{additionalParameters}";
            }

            return $"{url}{separator}w={width}";
        }

        public string Crop(string url, int width, int height)
        {
            if (url.IsNullOrEmpty())
            {
                return null;
            }

            var separator = url.Contains("?") ? "&" : "?";
            return $"{url}{separator}w={width}&h={height}&fit=crop&crop=edges";
        }
    }
}