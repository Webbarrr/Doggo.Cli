using System.Text;
using Doggo.Application.Contracts;
using Doggo.Application.Dtos;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Doggo.Application.Services;

public class AsciiArtRendererAppService : IAsciiArtRendererAppService
{
    private const string _asciiChars = "@%#*+=-:. "; // dark to light

    public string ConvertToAscii(ConvertToAsciiRequest request)
    {
        request.ValidateAndThrow();

        using var image = Image.Load<Rgba32>(request.ImageStream);

        int newWidth = Math.Min(request.MaxWidth, image.Width);
        int newHeight = (int)(image.Height / (double)image.Width * newWidth * 0.55); // adjust for character aspect ratio

        image.Mutate(x => x.Resize(newWidth, newHeight));

        var sb = new StringBuilder();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                var pixel = image[x, y];
                var brightness = (pixel.R + pixel.G + pixel.B) / 3f;
                var index = (int)((brightness / 255) * (_asciiChars.Length - 1));
                sb.Append(_asciiChars[index]);
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}