using Doggo.Cli.Commands;
using Spectre.Console.Cli;

namespace Doggo.Cli.DependencyWiring;

public static class CommandConfiguratorExtensions
{
    public static void ConfigureCommands(this IConfigurator config)
    {
        config.AddCommand<FetchCommand>("fetch")
            .WithDescription("Fetch a random dog image.")
            .WithExample(new[] { "fetch", "-b", "boxer" })
            .WithExample(new[] { "fetch", "--breed", "boxer" })
            .WithExample(new[] { "fetch", "-p", @"path\to\image" })
            .WithExample(new[] { "fetch", "--path", @"path\to\image" })
            .WithExample(new[] { "fetch", "-p", "imageurl.jpg" })
            .WithExample(new[] { "fetch", "--path", "imageurl.jpg" });
    }
}