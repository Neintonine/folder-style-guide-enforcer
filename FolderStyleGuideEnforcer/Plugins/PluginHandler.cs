namespace FolderStyleGuideEnforcer.Plugins;

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

        foreach (string path in _pluginPaths)
        {
            foreach (string file in Directory.EnumerateFiles(path, searchPattern: "*.dll", SearchOption.AllDirectories))
            {
                Plugin plugin = new Plugin(file);

                if (autoload)
                {
                    plugin.Load();
                }
                
                plugins.Add(plugin);
            }
        }

        return (IReadOnlyList<Plugin>)plugins;
    }

    public Plugin LoadPlugin(string path)
    {
        return new Plugin(path);
    }
}