namespace Doggo.Application.Contracts;

public interface IImageDownloader
{
    Task<byte[]> GetImageBytesAsync(string imageUrl);
}