namespace Doggo.Application.Dtos;
public record ConvertToAsciiRequest
{
    public Stream ImageStream { get; init; }
    public int MaxWidth { get; init; } = 100;

    public void ValidateAndThrow()
    {
        if (ImageStream == null)
        {
            throw new ArgumentNullException(nameof(ImageStream), "Image stream cannot be null.");
        }

        if (MaxWidth <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxWidth), "Max width must be greater than zero.");
        }
    }
}