using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Source
    {
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
    }
}