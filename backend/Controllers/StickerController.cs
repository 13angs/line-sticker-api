using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class StickerController : ControllerBase
    {
        private readonly ISticker _sticker;
        private readonly ObjectStorageService _objSv;
        public StickerController(ISticker sticker, ObjectStorageService objSv)
        {
            _sticker = sticker;
            _objSv = objSv;
        }
        [HttpGet]
        [Route("line/packages")]
        public async Task<IEnumerable<LineStickerPackageModel>> GetPackages()
        {
            return await _sticker.GetPackages();
        }

        [HttpGet]
        [Route("line/stickers")]
        public async Task<IEnumerable<LineStickerDetail>> GetStickers([FromQuery] long packageId)
        {
            return await _sticker.GetStickers(packageId);
        }
        
        [HttpGet]
        [Route("facebook/stickers")]
        public async Task<ActionResult> GetFbStickers()
        {
            return Ok(await _objSv.GetFiles());
        }
    }
}
