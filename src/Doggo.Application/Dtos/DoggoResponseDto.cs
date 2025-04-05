using System.Text.Json.Serialization;

namespace Doggo.Application.Dtos;

public class DoggoResponseDto
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}