using FSGE.Framework.Repository;

namespace FSGE.Framework.Configuration;

public interface IConfigurationPreset : IDiscoverable
{
    Configuration GetConfiguration();
}