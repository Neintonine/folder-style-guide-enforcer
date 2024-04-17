namespace FolderStyleGuideEnforcer.FileProviders;

internal class FileProviderFactory
{
    public IEnumerable<string> Get(CheckCommand.Settings settings)
    {
        string searchDirectory = settings.Directory ?? Directory.GetCurrentDirectory();
        return new DirectoryProvider(searchDirectory);
    }
}