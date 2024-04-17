using System.Collections;

namespace FolderStyleGuideEnforcer.FileProviders;

public class DirectoryProvider: IEnumerable<string>
{
    private IEnumerable<string> _directoryEnum;

    public DirectoryProvider(string path)
    {
        _directoryEnum = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _directoryEnum.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}