namespace FolderStyleGuideEnforcer.Repository;

public interface INamedDiscoverable: IDiscoverable
{
    
    public string GetDisplayName();
    public string GetDescription();
}