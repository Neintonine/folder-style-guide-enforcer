namespace FSGE.Framework.Repository;

public interface INamedDiscoverable: IDiscoverable
{
    
    public string GetDisplayName();
    public string GetDescription();
}