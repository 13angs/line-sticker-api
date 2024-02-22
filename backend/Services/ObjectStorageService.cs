using Amazon.S3;
using Amazon.S3.Model;
using backend.Models;

namespace backend.Services
{
    public class ObjectStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ObjectStorageService> _logger;
        public ObjectStorageService(IConfiguration configuration, ILogger<ObjectStorageService> logger)
        {
            _configuration = configuration;
            var options = new AmazonS3Config
            {
                ServiceURL = _configuration["S3Config:ServiceUrl"]
            };
            // Initialize the S3 client here, or use dependency injection to inject it.
            _s3Client = new AmazonS3Client(_configuration["S3Config:AccessKey"], _configuration["S3Config:SecretKey"], options);
            _logger = logger;
        }

        public async Task<object> GetFiles()
        {
            // Create an Amazon S3 client with your credentials and region.
            ListObjectsV2Response? response = new ListObjectsV2Response();
            string bucketName = _configuration["S3Config:BucketName"];
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    Prefix = Path.Combine("files", "stickers/facebook/women-15") + "/",
                    // MaxKeys = 5
                };

                do
                {
                    response = await _s3Client.ListObjectsV2Async(request);


                    request.ContinuationToken = response.NextContinuationToken;
                } while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine($"S3 Error: {amazonS3Exception.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            // Console.WriteLine(JsonConvert.SerializeObject(staticModels));
            List<FacebookSticker> stickers = new List<FacebookSticker>();
            string objectUrl = $"https://{bucketName}.ap-south-1.linodeobjects.com";

            foreach(var s3Object in response.S3Objects)
            {
                var sticker = new FacebookSticker{
                    Name=s3Object.Key.Split("/").Last().Split(".").First(),
                    Url=Path.Combine(objectUrl, s3Object.Key)
                };
                stickers.Add(sticker);
            }
            return stickers;
        }
    }
}