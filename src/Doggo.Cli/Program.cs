using Doggo.Cli.DependencyWiring;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

internal class Program
{
    public static async Task<int> Main(string[] args)
    {
        args = new[] { "fetch", "-b", "donut" };

        var registrations = new ServiceCollection();
        registrations.AddServices();

        var registrar = new TypeRegistrar(registrations);
        var app = new CommandApp(registrar);

        app.Configure(config =>
        {
            config.PropagateExceptions();
            config.ConfigureCommands();
        });

        try
        {
            return await app.RunAsync(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -99;
        }
    }
}