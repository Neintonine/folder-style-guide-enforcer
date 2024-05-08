using System.Collections;

namespace FSGE.Framework.FileProviders;

public sealed class DirectoryProviderEnumerator: IEnumerator<string>
{
    private readonly string _absolutePath;
    private IEnumerator<string> _enumerator;

    public DirectoryProviderEnumerator(string absolutePath, IEnumerator<string> enumerator)
    {
        this._absolutePath = absolutePath;
        this._enumerator = enumerator;
    }
    
    public bool MoveNext()
    {
        return this._enumerator.MoveNext();
    }

    public void Reset()
    {
        this._enumerator.Reset();
    }

    public string Current => Path.GetRelativePath(this._absolutePath, this._enumerator.Current);

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
        this._enumerator.Dispose();
    }
}