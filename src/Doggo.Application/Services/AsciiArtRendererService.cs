using System.Text;
using Doggo.Application.Contracts;
using Doggo.Application.Dtos;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Doggo.Application.Services;

public class AsciiArtRendererService : IAsciiArtRendererService
{
    private const string _asciiChars = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/|()1{}?-_+~<>i!lI;:,\".";

    public string ConvertToAscii(ConvertToAsciiRequest request)
    {
        request.ValidateAndThrow();

        using var image = Image.Load<Rgba32>(request.ImageStream);
        ResizeImage(image, request.MaxWidth, request.MaxHeight);

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

    private Image<Rgba32> ResizeImage(Image<Rgba32> image, int maxWidth, int maxHeight)
    {
        const double charAspectRatio = 0.45;

        double widthScale = maxWidth / (double)image.Width;
        double heightScale = maxHeight / (image.Height * charAspectRatio);

        double scale = Math.Min(widthScale, heightScale);

        int newWidth = (int)(image.Width * scale);
        int newHeight = (int)(image.Height * scale * charAspectRatio);

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
        int index = (int)Math.Ceiling((_asciiChars.Length - 1) * brightness / 255);
        index = Math.Min(index, _asciiChars.Length - 1);
        return _asciiChars[index];
    }
}