using FSGE.Framework.Configuration;
using FSGE.Framework.Plugins;
using Spectre.Console;
using Spectre.Console.Cli;
// ReSharper disable ClassNeverInstantiated.Global

namespace FSGE.CLI.Commands.Config;

public class ListCommand : Command
{
    public override int Execute(CommandContext context)
    {
        PluginConfigurator configurator = new PluginConfigurator();
        PluginHandler handler = configurator.GetHandler(null);
        IReadOnlyList<Plugin> plugins = handler.DiscoverPlugins(true);

        ConfigurationPresetRepository presetRepository = new ConfigurationPresetRepository();
        presetRepository.Discover(plugins);

        IReadOnlyDictionary<string,IConfigurationPreset> presets = presetRepository.GetAll();
        AnsiConsole.WriteLine("The following presets are available:");
        foreach (var (key, _) in presets)
        {
            AnsiConsole.WriteLine($"- {key}");
        }

        return 0;
    }
}