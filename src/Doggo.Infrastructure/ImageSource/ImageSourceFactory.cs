using Doggo.Application.Contracts;

namespace Doggo.Infrastructure.ImageSource;

public class ImageSourceFactory : IImageSourceFactory
{
    private readonly ApiImageSource _apiImageSource;
    private readonly LocalFileImageSource _localFileImageSource;

    public ImageSourceFactory(
        ApiImageSource apiImageSource,
        LocalFileImageSource localFileImageSource)
    {
        _apiImageSource = apiImageSource;
        _localFileImageSource = localFileImageSource;
    }

    public IImageSource Create(string pathOrUrl)
    {
        if (Uri.IsWellFormedUriString(pathOrUrl, UriKind.Absolute))
        {
            return _apiImageSource;
        }

        return _localFileImageSource;
    }
}