using FSGE.Framework.Plugins;

namespace FSGE.Framework.Repository;

public class DiscoverableRepository<T>
    where T : IDiscoverable
{
    private readonly Dictionary<string, T> _foundModels = new Dictionary<string, T>();

    public int Discover(IReadOnlyList<Plugin> plugins)
    {
        foreach (Plugin plugin in plugins)
        {
            this.Discover(plugin);
        }
        return this._foundModels.Count;
    }

    public void Discover(Plugin plugin)
    {
        foreach (Type type in plugin.Assembly.GetTypes())
        {
            if (!type.IsPublic)
            {
                continue;
            }

            this.HandleType(type);
        }
    }

    public void Add(T item)
    {
        string internalName = item.GetInternalName();
        this._foundModels.Add(internalName, item); 
    }

    public bool Has(string value)
    {
        return this._foundModels.ContainsKey(value);
    }

    public T Get(string value)
    {
        if (!this._foundModels.ContainsKey(value))
        {
            return default;
        }

        return this._foundModels[value];
    }

    private void HandleType(Type type)
    {
        if (!type.GetInterfaces().Contains(typeof(T)))
        {
            return;
        }

        T item = (T)Activator.CreateInstance(type);
        this.Add(item);
    }
}