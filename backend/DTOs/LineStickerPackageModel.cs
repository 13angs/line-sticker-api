using backend.Models;
using Newtonsoft.Json;

namespace backend.DTOs
{
    public class LineStickerPackageModel : LineStickerPackage
    {
        [JsonProperty("preview_url")]
        public virtual string? PreviewUrl { get; set; }

        [JsonIgnoreAttribute]
        public override StickerIdRange? StickerIdRange {get; set;}
    }

}