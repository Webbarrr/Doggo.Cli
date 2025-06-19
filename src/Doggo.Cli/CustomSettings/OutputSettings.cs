using Spectre.Console.Cli;
using System.ComponentModel;

namespace Doggo.Cli.CustomSettings;

public class OutputSettings : CommandSettings
{
    [CommandOption("--output")]
    [Description("Optional output file path.")]
    public string? Output { get; set; }
}