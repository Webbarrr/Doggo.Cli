namespace Doggo.Application.Dtos
{
    public record RenderImageAppServiceResponse
    {
        public string OriginalImageUrl { get; init; } = string.Empty;
        public string Ascii { get; init; } = string.Empty;
    }
}