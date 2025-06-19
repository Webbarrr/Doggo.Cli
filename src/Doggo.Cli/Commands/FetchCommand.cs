using Doggo.Application.Contracts;
using Doggo.Application.Dtos;
using Doggo.Cli.CustomSettings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Doggo.Cli.Commands;

public class FetchCommand : AsyncCommand<FetchCommand.Settings>
{
    private readonly IRenderImageAppService _renderImageAppService;
    private readonly IOutputAppService _outputAppService;

    public class Settings : OutputSettings
    {
        [CommandOption("-b|--breed")]
        public string Breed { get; set; } = string.Empty;

        [CommandOption("-p|--path")]
        public string Path { get; set; } = string.Empty;
    }

    public FetchCommand(
        IRenderImageAppService renderImageAppService,
        IOutputAppService outputAppService)
    {
        _renderImageAppService = renderImageAppService;
        _outputAppService = outputAppService;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var request = new RenderImageAppServiceRequest
        {
            Breed = settings.Breed,
            Path = settings.Path,
        };
        request.ValidateAndThrow();

        var response = await _renderImageAppService.ExecuteAsync(request);
        AnsiConsole.Markup(response.Ascii);
        AnsiConsole.Write("Original image url: {0}", response.OriginalImageUrl);

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var path = _outputAppService.Output(settings.Output, response.Ascii);
            AnsiConsole.Write("Outputted to {0}", settings.Output);
        }

        return 0;
    }
}