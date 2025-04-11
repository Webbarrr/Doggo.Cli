namespace Doggo.Application.Dtos;

public record RenderImageAppServiceRequest
{
    public string? Breed { get; init; }
    public string? Path { get; init; }

    public void ValidateAndThrow()
    {
        if (!string.IsNullOrWhiteSpace(Breed) && !string.IsNullOrWhiteSpace(Path))
        {
            throw new ArgumentException($"Cannot provide {nameof(Breed)} and {nameof(Path)} arguments.");
        }
    }
}
