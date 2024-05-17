using System.ComponentModel;
using FSGE.Framework.Configuration;
using Newtonsoft.Json;
using Spectre.Console.Cli;

namespace FSGE.CLI.Commands.Config;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class CreateCommand: Command<CreateCommand.Settings>
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[preset]")]
        [Description("If specified, generates a configuration with a specific preset. Call '--list-presets' to view all presets.")]
        public string? Preset { get; init; }
        
        [CommandOption("--list-preset")]
        [Description("If set, instead of creating a configuration, it displays all presets.")]
        public bool ListPresets { get; init; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        Configuration config = new ConfigurationHandler().CreateEmpty();
        string configString = JsonConvert.SerializeObject(config, Formatting.Indented);

        string path = Path.Combine(Environment.CurrentDirectory, ".fsge-config");
        
        File.WriteAllText(path, configString);
        return 0;
    }
}