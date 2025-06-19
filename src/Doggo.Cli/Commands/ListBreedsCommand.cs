using Doggo.Application.Contracts;
using Doggo.Cli.CustomSettings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Doggo.Cli.Commands;

public class ListBreedsCommand : AsyncCommand<ListBreedsCommand.Settings>
{
    public class Settings : OutputSettings
    {

    }

    private readonly IDoggoClient _doggoClient;
    private readonly IOutputAppService _outputAppService;

    public ListBreedsCommand(
        IDoggoClient doggoClient,
        IOutputAppService outputAppService)
    {
        _doggoClient = doggoClient;
        _outputAppService = outputAppService;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var breeds = await _doggoClient.ListBreedsAsync();

        var table = new Table();
        table.AddColumn("Breed");

        foreach (var breed in breeds)
            table.AddRow(breed);

        AnsiConsole.Write(table);

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var path = _outputAppService.Output(settings.Output, breeds);
            AnsiConsole.Write("Outputted to {0}", settings.Output);
        }

        return 0;
    }
}