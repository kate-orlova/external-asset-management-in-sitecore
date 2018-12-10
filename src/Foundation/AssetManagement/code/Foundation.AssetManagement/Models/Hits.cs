using System.Collections.Generic;
using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Hits
    {
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("max_score")] public double? MaxScore { get; set; }
        [JsonProperty("hits")] public IList<Hit> HitList { get; set; }
    }
}