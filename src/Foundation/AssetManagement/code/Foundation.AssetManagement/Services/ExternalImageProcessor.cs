using System.Text.RegularExpressions;
using Foundation.AssetManagement.Extensions;
using Foundation.AssetManagement.Interfaces;
using Sitecore.StringExtensions;

namespace Foundation.AssetManagement.Services
{
    public class ExternalImageProcessor : IExternalImageProcessor
    {
        private static Regex WidthRegex = new Regex(@"w=(?<width>\d+)", RegexOptions.Compiled);
        private static Regex HeightRegex = new Regex(@"h=(?<height>\d+)", RegexOptions.Compiled);

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

                var widthMatch = WidthRegex.Match(additionalParameters);
                if (widthMatch.Success)
                {
                    sourceWidth = widthMatch.Groups["width"].Value.ToInt();
                }

                var heightMatch = HeightRegex.Match(additionalParameters);
                if (heightMatch.Success)
                {
                    sourceHeight = heightMatch.Groups["height"].Value.ToInt();
                }

                if (sourceWidth > 0 & sourceHeight > 0)
                {
                    sizeIsPredefined = true;
                    var newHeight = width * sourceHeight / sourceWidth;
                    additionalParameters = additionalParameters.Replace(widthMatch.Groups["width"].Value, width.ToString());
                    additionalParameters = additionalParameters.Replace(heightMatch.Groups["height"].Value, newHeight.ToString());
                }

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