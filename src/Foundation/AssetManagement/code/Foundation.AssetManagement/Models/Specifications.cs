using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Specifications
    {
        [JsonProperty("File / Color space")] public string ColorSpace { get; set; }
    }
}