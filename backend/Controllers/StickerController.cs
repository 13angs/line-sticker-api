using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/line")]
    public class StickerController : ControllerBase
    {
        private readonly ISticker _sticker;
        public StickerController(ISticker sticker)
        {
            _sticker = sticker;
        }
        [HttpGet]
        [Route("packages")]
        public async Task<IEnumerable<LineStickerPackage>> GetPackages()
        {
            return await _sticker.GetPackages();
        }

        [HttpGet]
        [Route("stickers")]
        public async Task<IEnumerable<LineStickerDetail>> GetStickers([FromQuery] long packageId)
        {
            return await _sticker.GetStickers(packageId);
        }
    }
}
