using System.Text.Json;
using Doggo.Application.Contracts;
using Doggo.Application.Dtos;

namespace Doggo.Infrastructure;

public class DoggoClient : IDoggoClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://dog.ceo/api/";

    public DoggoClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DoggoResponseDto> RandomAsync()
    {
        var url = $"{_baseUrl}breeds/image/random";
        var uri = new Uri(url);

        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        var jsonResponse = await SendRequest(request);

        return HandleResponse(jsonResponse);
    }

    public async Task<DoggoResponseDto> RandomByBreedAsync(string breed)
    {
        if (string.IsNullOrWhiteSpace(breed))
        {
            throw new ArgumentException("Breed cannot be null or empty", nameof(breed));
        }

        var url = $"{_baseUrl}breed/{breed}/images/random";
        var uri = new Uri(url);

        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        var jsonResponse = await SendRequest(request);

        return HandleResponse(jsonResponse);
    }

    private async Task<string> SendRequest(HttpRequestMessage request)
    {
        var response = await _httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        else
        {
            throw new Exception($"Request failed with status code: {response.StatusCode}");
        }
    }

    private DoggoResponseDto HandleResponse(string? jsonResponse)
    {
        if (string.IsNullOrEmpty(jsonResponse))
        {
            throw new Exception("Response is empty");
        }

        var response = JsonSerializer.Deserialize<DoggoResponseDto>(jsonResponse);
        if (response == null)
        {
            throw new Exception("Deserialization failed");
        }
        return response;
    }
}