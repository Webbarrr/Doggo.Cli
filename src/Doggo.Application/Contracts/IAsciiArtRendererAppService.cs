using Doggo.Application.Dtos;

namespace Doggo.Application.Contracts;
public interface IAsciiArtRendererAppService
{
    string ConvertToAscii(ConvertToAsciiRequest request);
}