using Doggo.Application.Contracts;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Doggo.Cli.Commands;

public class ListBreedsCommand : AsyncCommand
{
    private readonly IDoggoClient _doggoClient;

    public ListBreedsCommand(IDoggoClient doggoClient)
    {
        _doggoClient = doggoClient;
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        var breeds = await _doggoClient.ListBreedsAsync();

        var table = new Spectre.Console.Table();
        table.AddColumn("Breed");

        foreach (var breed in breeds)
            table.AddRow(breed);

        AnsiConsole.Write(table);

        return 0;
    }
}