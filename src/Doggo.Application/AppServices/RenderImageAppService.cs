using Doggo.Application.Contracts;
using Doggo.Application.Dtos;

namespace Doggo.Application.AppServices;

public class RenderImageAppService : IRenderImageAppService
{
    private readonly IDoggoClient _doggoClient;
    private readonly IAsciiArtRendererService _asciiArtRendererAppService;
    private readonly IImageSourceFactory _imageSourceFactory;

    public RenderImageAppService(
        IDoggoClient doggoClient,
        IAsciiArtRendererService asciiArtRendererAppService,
        IImageSourceFactory imageSourceFactory)
    {
        _doggoClient = doggoClient;
        _asciiArtRendererAppService = asciiArtRendererAppService;
        _imageSourceFactory = imageSourceFactory;
    }

    public async Task<RenderImageAppServiceResponse> ExecuteAsync(RenderImageAppServiceRequest request)
    {
        DoggoResponseDto doggoResponse;
        string source;

        if (string.IsNullOrWhiteSpace(request.Path))
        {
            if (string.IsNullOrWhiteSpace(request.Breed))
            {
                doggoResponse = await _doggoClient.RandomAsync();
            }
            else
            {
                doggoResponse = await _doggoClient.RandomByBreedAsync(request.Breed);
            }
            source = doggoResponse.Message;
        }
        else
        {
            source = request.Path;
        }

        IImageSource imageSource = _imageSourceFactory.Create(source);
        var bytes = await imageSource.GetImageBytesAsync(source);

        using var stream = new MemoryStream(bytes);
        var ascii = _asciiArtRendererAppService.ConvertToAscii(new ConvertToAsciiRequest
        {
            ImageStream = stream,
            MaxWidth = 80,
            MaxHeight = 80,
        });

        if (string.IsNullOrWhiteSpace(ascii))
        {
            throw new Exception("Failed to convert image to ASCII.");
        }

        return new RenderImageAppServiceResponse
        {
            Ascii = ascii,
            OriginalImageUrl = source,
        };
    }
}