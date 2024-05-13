using System.Reflection;
using FSGE.Framework.Plugins;

namespace FSGE.CLI;

public sealed class PluginConfigurator
{
    public string GetDefaultPath()
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "plugins");
    }
    
    public PluginHandler GetHandlerSeperatedBy(string? requestedPluginDirectories, string seperator = ";")
    {
        if (requestedPluginDirectories == null)
        {
            return GetHandler(null);
        }

        return GetHandler(requestedPluginDirectories.Split(seperator));
    }
    
    public PluginHandler GetHandler(string[]? requestedPluginDirectories)
    {
        if (requestedPluginDirectories == null)
        {
            string? directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "plugins");

            if (directory == null)
            {
                throw new Exception("Couldn't find directory for plugins");
            }

            return new PluginHandler(new [] { directory });
        }

        return new PluginHandler(requestedPluginDirectories); 
    }
}