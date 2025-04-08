using System.Text;
using Doggo.Application.Contracts;
using Doggo.Application.Dtos;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Doggo.Application.Services;

public class AsciiArtRendererService : IAsciiArtRendererService
{
    private const string _asciiChars = "@#*+=-:. ";  // dark to light

    public string ConvertToAscii(ConvertToAsciiRequest request)
    {
        request.ValidateAndThrow();

        using var image = Image.Load<Rgba32>(request.ImageStream);
        ResizeImage(image, request.MaxWidth);

        var sb = new StringBuilder();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                var pixel = image[x, y];
                float brightness = GetBrightness(pixel);
                char asciiChar = GetAsciiChar(brightness);
                string color = ToHexColor(pixel);

                sb.Append($"[{color}]{asciiChar}[/]");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }


    private Image<Rgba32> ResizeImage(Image<Rgba32> image, int maxWidth)
    {
        int newWidth = Math.Min(maxWidth, image.Width);
        int newHeight = (int)(image.Height / (double)image.Width * newWidth * 0.45);

        image.Mutate(x => x.Resize(newWidth, newHeight));
        return image;
    }

    private float GetBrightness(Rgba32 pixel)
    {
        return 0.2126f * pixel.R + 0.7152f * pixel.G + 0.0722f * pixel.B;
    }

    private string ToHexColor(Rgba32 pixel)
    {
        return $"#{pixel.R:X2}{pixel.G:X2}{pixel.B:X2}";
    }

    private char GetAsciiChar(float brightness)
    {
        int index = (int)((brightness / 255) * (_asciiChars.Length - 1));
        return _asciiChars[index];
    }
}