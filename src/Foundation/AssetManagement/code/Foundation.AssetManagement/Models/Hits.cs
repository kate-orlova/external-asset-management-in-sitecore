﻿using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Hits
    {
        [JsonProperty("total")] public int Total { get; set; }
    }
}