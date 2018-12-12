using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Metadata
    {
        [JsonProperty("Specifications")] public Specifications Specifications { get; set; }
    }
}