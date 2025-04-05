namespace Doggo.Application.Contracts;

public interface IRenderImageAppService
{
    Task<string> ExecuteAsync(string? breed);
}