namespace Foundation.AssetManagement.Interfaces
{
    public interface IExternalImageProcessor
    {
        string Resize(string url, int width, string additionalParameters);
    }
}