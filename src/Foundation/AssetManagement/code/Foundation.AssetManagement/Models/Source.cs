using Newtonsoft.Json;
using System;

namespace Foundation.AssetManagement.Models
{
    public class Source
    {
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("metadata")] public Metadata Metadata { get; set; }
        [JsonProperty("public_url")] public string PublicUrl { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("thumbnail")] public Thumbnail Thumbnail { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("updated")] public DateTime Updated { get; set; }
        [JsonProperty("last_indexed_date")] public DateTime LastIndexedDate { get; set; }
        [JsonProperty("visibility")] public string Visibility { get; set; }
    }
}