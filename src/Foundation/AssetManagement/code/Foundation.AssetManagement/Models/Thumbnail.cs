using Newtonsoft.Json;

namespace Foundation.AssetManagement.Models
{
    public class Thumbnail
    {
        [JsonProperty("mime_type")] public string MimeType { get; set; }
        [JsonProperty("base64")] public string Base64 { get; set; }
    }
}