using Doggo.Application.Dtos;

namespace Doggo.Application.Contracts;
public interface IAsciiArtRendererService
{
    string ConvertToAscii(ConvertToAsciiRequest request);
}