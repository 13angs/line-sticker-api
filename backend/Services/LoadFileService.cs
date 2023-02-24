using backend.Interfaces;
using Newtonsoft.Json;

namespace backend.Services
{
    public class LoadFileService : ILoadFile
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<LoadFileService> _logger;
        public LoadFileService(IHostEnvironment env, ILogger<LoadFileService> logger)
        {
            _env = env;
            _logger = logger;
        }
        public async Task<string> LoadJson<T>()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "data.json");
            _logger.LogInformation($"Loading {filePath}");
            string json = await System.IO.File.ReadAllTextAsync(filePath);
            T data = JsonConvert.DeserializeObject<T>(json)!;
            return JsonConvert.SerializeObject(data);
        }
    }
}
