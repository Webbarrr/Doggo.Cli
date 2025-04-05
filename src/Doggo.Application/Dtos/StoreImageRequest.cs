namespace Doggo.Application.Dtos;

public record StoreImageRequest
{
    public byte[] Bytes { get; init; } = Array.Empty<byte>();
    public string FilePath { get; init; } = string.Empty;

    public void ValidateAndThrow()
    {
        if (string.IsNullOrWhiteSpace(FilePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(FilePath));
        }

        if (Bytes == null || Bytes.Length == 0 || Bytes == Array.Empty<byte>())
        {
            throw new ArgumentException("Image bytes cannot be null or empty.", nameof(Bytes));
        }
    }
}