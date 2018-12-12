using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Metadata
    {
        [JsonProperty("Details")] public dynamic Details { get; set; }
        [JsonProperty("Hidden")] public dynamic Hidden { get; set; }
        [JsonProperty("Specifications")] public Specifications Specifications { get; set; }
    }
}