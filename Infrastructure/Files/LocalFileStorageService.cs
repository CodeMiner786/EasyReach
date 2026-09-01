using EasyReach_Application.Files;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EasyReach_Infrastructure.Files
{
    public class LocalFileStorageService(IOptions<StorageSettings> settings, IHostEnvironment env, ILogger<LocalFileStorageService> logger) : IFileStorageService
    {
        private readonly StorageSettings _settings = settings.Value;
        private readonly IHostEnvironment _env = env;
        private readonly ILogger<LocalFileStorageService> _logger = logger;

        public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, string subFolder, CancellationToken cancellationToken = default)
        {
            var folder = Path.Combine(_env.ContentRootPath, _settings.LocalStoragePath, subFolder);
            Directory.CreateDirectory(folder);

            var safeFileName = $"{Guid.NewGuid():N}{Path.GetExtension(fileName)}";
            var fullPath = Path.Combine(folder, safeFileName);

            await using (var output = new FileStream(fullPath, FileMode.Create))
            {
                await fileStream.CopyToAsync(output, cancellationToken);
            }

            var url = $"{_settings.PublicBaseUrl.TrimEnd('/')}/uploads/{subFolder}/{safeFileName}";
            _logger.LogInformation("Saved file to local disk: {Path} → {Url}", fullPath, url);
            return url;
        }
    }
}
