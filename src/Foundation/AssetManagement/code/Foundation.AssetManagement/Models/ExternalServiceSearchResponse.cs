using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class ExternalServiceSearchResponse
    {
        [JsonProperty("took")] public int Took { get; set; }
        [JsonProperty("timed_out")] public bool TimedOut { get; set; }
        [JsonProperty("shards")] public Shards Shards { get; set; }
        [JsonProperty("hits")] public Hits Hits { get; set; }
    }
}