namespace backend.Interfaces
{
    public interface ILoadFile
    {
        public Task<string> LoadJson<T>();
    }
}