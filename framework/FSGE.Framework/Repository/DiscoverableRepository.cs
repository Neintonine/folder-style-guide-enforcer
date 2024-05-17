using FSGE.Framework.Plugins;

namespace FSGE.Framework.Repository;

public class DiscoverableRepository<T>
    where T : IDiscoverable
{
    protected readonly Dictionary<string, T> FoundModels = new Dictionary<string, T>();

    public int Discover(IReadOnlyList<Plugin> plugins)
    {
        foreach (Plugin plugin in plugins)
        {
            this.Discover(plugin);
        }
        return this.FoundModels.Count;
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
        this.FoundModels.Add(internalName, item); 
    }

    public bool Has(string value)
    {
        return this.FoundModels.ContainsKey(value);
    }

    public T Get(string value)
    {
        if (!this.FoundModels.ContainsKey(value))
        {
            return default;
        }

        return this.FoundModels[value];
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