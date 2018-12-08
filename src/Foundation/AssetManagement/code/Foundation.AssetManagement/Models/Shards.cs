using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Shards
    {
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("successful")] public int Successful { get; set; }
    }
}