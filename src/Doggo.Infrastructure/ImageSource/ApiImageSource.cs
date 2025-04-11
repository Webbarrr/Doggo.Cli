using Doggo.Application.Contracts;

namespace Doggo.Infrastructure.ImageSource;

public class ApiImageSource : IImageSource
{
    private readonly HttpClient _httpClient;

    public ApiImageSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GetImageBytesAsync(string imagePath)
    {
        var response = await _httpClient.GetAsync(imagePath);
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
