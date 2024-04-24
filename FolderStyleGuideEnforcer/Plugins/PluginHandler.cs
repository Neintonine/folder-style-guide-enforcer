namespace FolderStyleGuideEnforcer.Plugins;

public sealed class PluginHandler
{
    private readonly string _pluginPath;
    
    public PluginHandler(string pluginPath)
    {
        this._pluginPath = pluginPath;
    }

    public IReadOnlyList<Plugin> DiscoverPlugins(bool autoload = false)
    {
        IList<Plugin> plugins = new List<Plugin>();

        foreach (string file in Directory.EnumerateFiles(this._pluginPath, searchPattern: "*.dll", SearchOption.AllDirectories))
        {
            Plugin plugin = new Plugin(file);

            if (autoload)
            {
                plugin.Load();
            }
            
            plugins.Add(plugin);
        }

        return (IReadOnlyList<Plugin>)plugins;
    }

    public Plugin LoadPlugin(string path)
    {
        return new Plugin(path);
    }
}