using Doggo.Application.Contracts;

namespace Doggo.Infrastructure.ImageSource;

public class LocalFileImageSource : IImageSource
{
    public async Task<byte[]> GetImageBytesAsync(string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            throw new ArgumentException("Image path cannot be null or empty.", nameof(imagePath));
        }

        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException($"No file found at path: {imagePath}", imagePath);
        }

        return await File.ReadAllBytesAsync(imagePath);
    }
}