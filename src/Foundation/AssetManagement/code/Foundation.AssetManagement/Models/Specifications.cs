using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Specifications
    {
        [JsonProperty("File / Color space")] public string ColorSpace { get; set; }
        [JsonProperty("File / File size")] public string FileSize { get; set; }
        [JsonProperty("File / Image size")] public string ImageSize { get; set; }
    }
}