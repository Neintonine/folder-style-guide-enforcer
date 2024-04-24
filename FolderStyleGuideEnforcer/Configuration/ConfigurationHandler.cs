using Newtonsoft.Json;

namespace FolderStyleGuideEnforcer.Configuration;

public sealed class ConfigurationHandler
{
    public Configuration GetFromDirectory(string path)
    {
        string expectedPath = Path.Combine(path, ".fsge-config");

        return this.GetFromFile(expectedPath);
    }

    public Configuration GetFromFile(string configPath)
    {
        if (!File.Exists(configPath))
        {
            return new Configuration(
                Array.Empty<string>(),
                new Dictionary<string, string>(),
                Array.Empty<string>()
            );
        }

        string config = File.ReadAllText(configPath);
        Configuration? configObj = JsonConvert.DeserializeObject<Configuration>(config);
        if (configObj == null)
        {
            throw new Exception("Couldn't create configuration object");
        }

        return configObj;
    }
}