using System.Reflection;

namespace FSGE.Framework.Plugins;

public class Plugin
{
    public string Path { get; }
    public Assembly Assembly { get; private set; }

    public Plugin(string path)
    {
        this.Path = path;
    }

    public bool Load()
    {
        try
        {
            this.Assembly = Assembly.LoadFile(this.Path);
            return true;
        }
        catch
        {
            return false;
        }
    }
}