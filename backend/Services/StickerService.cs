using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Services
{
    public class StickerService : ISticker
    {
        private readonly ILoadFile _fileService;
        private readonly IConfiguration _configuration;
        public StickerService(ILoadFile fileService, IConfiguration configuration)
        {
            _fileService = fileService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<LineStickerPackage>> GetPackages()
        {
            string strPackage = await _fileService.LoadJson<IEnumerable<LineStickerPackage>>();
            IEnumerable<LineStickerPackage> packages = JsonConvert
                            .DeserializeObject<IEnumerable<LineStickerPackage>>(strPackage)!;
            return packages;
        }

        public async Task<IEnumerable<LineStickerDetail>> GetStickers(long packageId)
        {
            string url = _configuration["StickerUrl"];
            url = url.Replace(":stickerid", "");
            string strSticker = await _fileService.LoadJson<IEnumerable<LineSticker>>();
            IEnumerable<LineSticker> stickers = JsonConvert
                            .DeserializeObject<IEnumerable<LineSticker>>(strSticker)!;
            LineStickerPackage package = stickers.FirstOrDefault(s => s.PackageId == packageId)!;
            List<LineStickerDetail> details = new List<LineStickerDetail>();
            for(long i=package.StickerIdRange!.From; i <= package.StickerIdRange.To; i++)
            {
                details.Add(new LineStickerDetail{
                    StickerId=i,
                    Url=_configuration["StickerUrl"].Replace(":stickerid", i.ToString())
                });
            }
            return details;
        }
    }
}
