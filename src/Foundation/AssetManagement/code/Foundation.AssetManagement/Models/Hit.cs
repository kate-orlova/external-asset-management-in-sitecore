using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Hit
    {
        [JsonProperty("_index")] public string Index { get; set; }
    }
}