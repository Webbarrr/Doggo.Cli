namespace Doggo.Application.Contracts;

public interface IImageSourceFactory
{
    IImageSource Create(string pathOrUrl);
}