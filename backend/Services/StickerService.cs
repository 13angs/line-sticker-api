using backend.Interfaces;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Services
{
    public class StickerService : ISticker
    {
        private readonly ILoadFile _fileService;
        public StickerService(ILoadFile fileService)
        {
            _fileService = fileService;
        }

        public async Task<IEnumerable<LineStickerPackage>> GetPackages()
        {
            string strPackage = await _fileService.LoadJson<IEnumerable<LineStickerPackage>>();
            IEnumerable<LineStickerPackage> packages = JsonConvert
                            .DeserializeObject<IEnumerable<LineStickerPackage>>(strPackage)!;
            return packages;
        }
    }
}
