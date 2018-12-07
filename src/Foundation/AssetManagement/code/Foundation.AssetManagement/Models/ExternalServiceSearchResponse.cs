﻿using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class ExternalServiceSearchResponse
    {
        [JsonProperty("took")] public int took { get; set; }
        [JsonProperty("timed_out")] public bool timed_out { get; set; }
        [JsonProperty("shards")] public Shards _shards { get; set; }
    }
}