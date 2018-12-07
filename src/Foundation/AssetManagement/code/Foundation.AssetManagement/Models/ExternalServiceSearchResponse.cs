using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class ExternalServiceSearchResponse
    {
        [JsonProperty("took")] public int took { get; set; }
    }
}