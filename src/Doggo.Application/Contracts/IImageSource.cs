namespace Doggo.Application.Contracts;

public interface IImageSource
{
    Task<byte[]> GetImageBytesAsync(string imagePath);
}
