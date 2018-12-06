using Foundation.AssetManagement.Models;

namespace Foundation.AssetManagement.Interfaces
{
    public interface IExternalService
    {
         ExternalServiceSearchResponse Search(string query, int startFrom, int pageSize);
    }
}
