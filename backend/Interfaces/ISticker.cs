using backend.Models;

namespace backend.Interfaces
{
    public interface ISticker
    {
        public Task<IEnumerable<LineStickerPackage>> GetPackages();
    }
}