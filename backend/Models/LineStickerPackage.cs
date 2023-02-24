using Newtonsoft.Json;

namespace backend.Models
{

    public partial class LineStickerPackage
    {
        [JsonProperty("package_id")]
        public virtual long PackageId { get; set; }

        [JsonProperty("title")]
        public virtual Title? Title { get; set; }

        [JsonProperty("sticker_id_range")]
        public virtual StickerIdRange? StickerIdRange { get; set; }
    }

    public partial class StickerIdRange
    {
        [JsonProperty("from")]
        public virtual long From { get; set; }

        [JsonProperty("to")]
        public virtual long To { get; set; }
    }

    public partial class Title
    {
        [JsonProperty("en")]
        public virtual string? En { get; set; }
    }
}
