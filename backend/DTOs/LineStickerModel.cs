using backend.Models;
using Newtonsoft.Json;

namespace backend.DTOs
{
    public class LineSticker : LineStickerPackage
    {
        public LineSticker()
        {
            LineStickers = new List<LineStickerDetail>();
        }

        [JsonProperty("line_stickers")]
        public List<LineStickerDetail> LineStickers { get; set; }
    }
    public class LineStickerDetail
    {
        [JsonProperty("sticker_id")]
        public long StickerId { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}