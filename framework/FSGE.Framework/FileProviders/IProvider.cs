namespace FSGE.Framework.FileProviders;

public interface IProvider : IEnumerable<string>
{
    public string GetAbsolutePath(string relativePath);
}