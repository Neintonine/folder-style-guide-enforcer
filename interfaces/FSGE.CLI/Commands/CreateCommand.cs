using FSGE.Framework.Configuration;
using Newtonsoft.Json;
using Spectre.Console.Cli;

namespace FSGE.CLI.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class CreateCommand: Command<CreateCommand.Settings>
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Settings : CommandSettings
    {
        
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