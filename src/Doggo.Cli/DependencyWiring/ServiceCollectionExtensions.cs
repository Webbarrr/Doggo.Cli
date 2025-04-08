using Doggo.Application.AppServices;
using Doggo.Application.Contracts;
using Doggo.Application.Services;
using Doggo.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Spectre;

namespace Doggo.Cli.DependencyWiring;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpClient();

        // logging
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Spectre()
            .CreateLogger();

        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog();
        });

        // infrastructure
        services.AddSingleton<IDoggoClient, DoggoClient>();
        services.AddSingleton<IImageDownloader, ImageDownloader>();

        // application
        services.AddSingleton<IRenderImageAppService, RenderImageAppService>();
        services.AddSingleton<IAsciiArtRendererService, AsciiArtRendererService>();
    }
}