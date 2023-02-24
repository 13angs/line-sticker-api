using backend.DTOs;
using backend.Models;

namespace backend.Interfaces
{
    public interface ISticker
    {
        public Task<IEnumerable<LineStickerPackage>> GetPackages();
        public Task<IEnumerable<LineStickerDetail>> GetStickers(long packageId);
    }
}