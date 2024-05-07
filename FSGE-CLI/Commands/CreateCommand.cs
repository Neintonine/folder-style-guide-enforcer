using FolderStyleGuideEnforcer.Configuration;
using Newtonsoft.Json;
using Spectre.Console.Cli;

namespace FSGE_CLI;

public sealed class CreateCommand: Command<CreateCommand.Settings>
{
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