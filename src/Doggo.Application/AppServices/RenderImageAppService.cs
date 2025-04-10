﻿using Doggo.Application.Contracts;
using Doggo.Application.Dtos;
using Microsoft.Extensions.Logging;

namespace Doggo.Application.AppServices;

public class RenderImageAppService : IRenderImageAppService
{
    private readonly ILogger<RenderImageAppService> _logger;
    private readonly IDoggoClient _doggoClient;
    private readonly IImageDownloader _imageDownloader;
    private readonly IAsciiArtRendererService _asciiArtRendererAppService;

    public RenderImageAppService(
        ILogger<RenderImageAppService> logger,
        IDoggoClient doggoClient,
        IImageDownloader imageDownloader,
        IAsciiArtRendererService asciiArtRendererAppService)
    {
        _logger = logger;
        _doggoClient = doggoClient;
        _imageDownloader = imageDownloader;
        _asciiArtRendererAppService = asciiArtRendererAppService;
    }

    public async Task<RenderImageAppServiceResponse> ExecuteAsync(string? breed)
    {
        DoggoResponseDto doggoResponse;

        if (string.IsNullOrWhiteSpace(breed))
        {
            doggoResponse = await _doggoClient.RandomAsync();
        }
        else
        {
            doggoResponse = await _doggoClient.RandomByBreedAsync(breed);
        }

        var bytes = await _imageDownloader.GetImageBytesAsync(doggoResponse.Message);

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
            OriginalImageUrl = doggoResponse.Message,
        };
    }
}