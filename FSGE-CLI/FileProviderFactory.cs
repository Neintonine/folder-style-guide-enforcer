using FolderStyleGuideEnforcer.FileProviders;

namespace FSGE_CLI;

internal class FileProviderFactory
{
    public IProvider Get(CheckCommand.Settings settings)
    {
        string searchDirectory = settings.Directory ?? Directory.GetCurrentDirectory();
        return new DirectoryProvider(searchDirectory);
    }
}