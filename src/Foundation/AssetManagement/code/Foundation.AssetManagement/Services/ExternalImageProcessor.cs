using Foundation.AssetManagement.Interfaces;

namespace Foundation.AssetManagement.Services
{
    public class ExternalImageProcessor : IExternalImageProcessor
    {
        public string Resize(string url, int width, string additionalParameters)
        {
            return null;
        }

        public string Crop(string url, int width, int height)
        {
            return null;
        }
    }
}