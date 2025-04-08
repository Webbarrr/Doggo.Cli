using Doggo.Application.Contracts;
using Doggo.Application.Dtos;

namespace Doggo.Infrastructure;

/// <summary>
/// Can be used to return a known image
/// </summary>
public class FakeDoggoClient : IDoggoClient
{
    public Task<DoggoResponseDto> RandomAsync()
    {
        return Task.FromResult(new DoggoResponseDto
        {
            Message = "https://images.dog.ceo/breeds/labrador/n02099712_8790.jpg",
            Status = "success",
        });
    }

    public Task<DoggoResponseDto> RandomByBreedAsync(string breed)
    {
        return Task.FromResult(new DoggoResponseDto
        {
            Message = "https://images.dog.ceo/breeds/labrador/n02099712_8790.jpg",
            Status = "success",
        });
    }
}