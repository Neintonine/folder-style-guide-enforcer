using FSGE.Framework.Repository;

namespace FSGE.Framework.Configuration;

public class ConfigurationPresetRepository : DiscoverableRepository<IConfigurationPreset>
{
    public IReadOnlyDictionary<string, IConfigurationPreset> GetAll()
    {
        return this.FoundModels;
    }
}