using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/line/packages")]
    public class StickerController : ControllerBase
    {
        private readonly ISticker _sticker;
        public StickerController(ISticker sticker)
        {
            _sticker = sticker;
        }
        [HttpGet]
        public async Task<IEnumerable<LineStickerPackage>> GetPackages()
        {
            return await _sticker.GetPackages();
        }
    }
}
