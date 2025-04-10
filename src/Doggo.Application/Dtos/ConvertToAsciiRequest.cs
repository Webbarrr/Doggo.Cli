namespace Doggo.Application.Dtos;
public record ConvertToAsciiRequest
{
    public Stream ImageStream { get; init; }
    public int MaxWidth { get; init; } = 100;
    public int MaxHeight { get; init; } = 100;

    public void ValidateAndThrow()
    {
        if (ImageStream == null)
        {
            throw new ArgumentNullException(nameof(ImageStream), "Image stream cannot be null.");
        }

        if (MaxWidth <= 0 || MaxWidth >= 101)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxWidth), "Max width must be greater than zero and less than 100.");
        }

        if (MaxHeight <= 0 || MaxHeight >= 101)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxWidth), "Max width must be greater than zero and less than 100.");
        }
    }
}