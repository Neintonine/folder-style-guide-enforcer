namespace FSGE.Framework.Plugins;

public sealed class PluginHandler
{
    private readonly string[] _pluginPaths;
    
    public PluginHandler(string[] pluginPaths)
    {
        this._pluginPaths = pluginPaths;
    }

    public IReadOnlyList<Plugin> DiscoverPlugins(bool autoload = false)
    {
        IList<Plugin> plugins = new List<Plugin>();

        foreach (string path in this._pluginPaths)
        {
            foreach (string file in Directory.EnumerateFiles(path, searchPattern: "*.dll", SearchOption.AllDirectories))
            {
                PluginHandler.ReadPlugin(autoload, file, plugins);
            }
        }

        return (IReadOnlyList<Plugin>)plugins;
    }

    public IReadOnlyDictionary<string, IReadOnlyList<Plugin>> DiscoverPluginsByDirectory(bool autoload = false)
    {
        IDictionary<string, IReadOnlyList<Plugin>> plugins = new Dictionary<string, IReadOnlyList<Plugin>>();

        foreach (string pluginPath in this._pluginPaths)
        {
            IList<Plugin> pluginsInPath = new List<Plugin>();
            
            foreach (string file in Directory.EnumerateFiles(pluginPath, searchPattern: "*.dll", SearchOption.AllDirectories))
            {
                PluginHandler.ReadPlugin(autoload, file, pluginsInPath);
            } 
            
            plugins.Add(pluginPath, (IReadOnlyList<Plugin>)pluginsInPath);
        }

        return plugins as IReadOnlyDictionary<string, IReadOnlyList<Plugin>>;
    }

    public Plugin LoadPlugin(string path)
    {
        return new Plugin(path);
    }
    private static void ReadPlugin(bool autoload, string file, IList<Plugin> plugins)
    {
        Plugin plugin = new Plugin(file);

        if (autoload)
        {
            plugin.Load();
        }
                
        plugins.Add(plugin);
    }
}