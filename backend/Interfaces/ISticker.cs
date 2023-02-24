using backend.DTOs;
using backend.Models;

namespace backend.Interfaces
{
    public interface ISticker
    {
        public Task<IEnumerable<LineStickerPackageModel>> GetPackages();
        public Task<IEnumerable<LineStickerDetail>> GetStickers(long packageId);
    }
}