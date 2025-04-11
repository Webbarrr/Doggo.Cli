using Doggo.Application.Dtos;

namespace Doggo.Application.Contracts;

public interface IRenderImageAppService
{
    Task<RenderImageAppServiceResponse> ExecuteAsync(RenderImageAppServiceRequest request);
}