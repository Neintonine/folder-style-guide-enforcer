using System.ComponentModel;
using FSGE.Framework.Configuration;
using FSGE.Framework.Plugins;
using Newtonsoft.Json;
using Spectre.Console;
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
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        Configuration? config = GetConfiguration(settings);
        if (config == null)
        {
            AnsiConsole.WriteLine($"Couldn't find preset with the name '{settings.Preset}'");
            
            return 1;
        }
        
        string configString = JsonConvert.SerializeObject(config, Formatting.Indented);

        string path = Path.Combine(Environment.CurrentDirectory, ".fsge-config");
        
        File.WriteAllText(path, configString);
        return 0;
    }

    private Configuration? GetConfiguration(Settings settings)
    {
        if (settings.Preset == null)
        {
            return new ConfigurationHandler().CreateEmpty();
        }

        PluginConfigurator configurator = new PluginConfigurator();
        PluginHandler handler = configurator.GetHandler(null);
        IReadOnlyList<Plugin> plugins = handler.DiscoverPlugins(true);
        
        ConfigurationPresetRepository repo = new ConfigurationPresetRepository();
        repo.Discover(plugins);

        if (!repo.Has(settings.Preset))
        {
            return null;
        }

        return repo.Get(settings.Preset).GetConfiguration();
    }
}