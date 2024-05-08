using FSGE.CLI.Commands;
using FSGE.Framework.FileProviders;

namespace FSGE.CLI;

internal class FileProviderFactory
{
    public IProvider Get(CheckCommand.Settings settings)
    {
        string searchDirectory = settings.Directory ?? Directory.GetCurrentDirectory();
        return new DirectoryProvider(searchDirectory);
    }
}