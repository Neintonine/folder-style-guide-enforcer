using System.ComponentModel;
using FSGE.Framework.Plugins;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FSGE.CLI.Commands.Plugins;

public sealed class ListCommand : Command<ListCommand.Settings>
{
    
    public class Settings : CommandSettings
    {
        [Description("Paths to the plugins; Seperate by semicolon")]
        [CommandOption("--pluginDir")]
        public string? PluginDirectory { get; init; }
    }


    public override int Execute(CommandContext context, Settings settings)
    {
        PluginHandler pluginHandler = new PluginConfigurator().GetHandlerSeperatedBy(settings.PluginDirectory);

        foreach ((string? path, IReadOnlyList<Plugin>? plugins) in pluginHandler.DiscoverPluginsByDirectory())
        {
            Tree tree = new Tree(path);
            foreach (Plugin plugin in plugins)
            {
                Uri uri = new Uri(plugin.Path);
                plugin.Load();
                
                tree.AddNode($"[yellow]{uri.Segments.Last()}[/]: {plugin.Assembly.FullName}");
            }
            
            AnsiConsole.Write(tree);
        }

        return 0;
    }
}