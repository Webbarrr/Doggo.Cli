using Doggo.Application.Dtos;

namespace Doggo.Application.Contracts;

public interface IDoggoClient
{
    Task<DoggoResponseDto> RandomAsync();
    Task<DoggoResponseDto> RandomByBreedAsync(string breed);
    Task<IEnumerable<string>> ListBreedsAsync();
}