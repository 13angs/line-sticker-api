using Newtonsoft.Json;

namespace backend.Models
{
    public class FacebookSticker
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}