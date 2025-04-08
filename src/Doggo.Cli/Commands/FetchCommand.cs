using Doggo.Application.Contracts;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Doggo.Cli.Commands;

public class FetchCommand : AsyncCommand<FetchCommand.Settings>
{
    private readonly IRenderImageAppService _renderImageAppService;

    public class Settings : CommandSettings
    {
        [CommandOption("-b|--breed")]
        public string Breed { get; set; } = string.Empty;
    }

    public FetchCommand(IRenderImageAppService renderImageAppService)
    {
        _renderImageAppService = renderImageAppService;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var response = await _renderImageAppService.ExecuteAsync(settings.Breed);
        AnsiConsole.Markup(response.Ascii);
        AnsiConsole.Write("Original image url: {0}", response.OriginalImageUrl);
        return 1;
    }
}