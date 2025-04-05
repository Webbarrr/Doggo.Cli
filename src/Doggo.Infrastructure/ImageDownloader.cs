using Doggo.Application.Contracts;

namespace Doggo.Infrastructure;

public class ImageDownloader : IImageDownloader
{
    private readonly HttpClient _httpClient;

    public ImageDownloader(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GetImageBytesAsync(string imageUrl)
    {
        var response = await _httpClient.GetAsync(imageUrl);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsByteArrayAsync();
        }
        else
        {
            throw new Exception($"Failed to download image. Status code: {response.StatusCode}");
        }
    }
}