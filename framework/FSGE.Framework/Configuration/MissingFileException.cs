namespace FSGE.Framework.Configuration;

public sealed class MissingFileException : Exception
{
    private MissingFileException(string message): base(message)
    {
        
    }

    public static MissingFileException WithPath(string path)
    {
        return new MissingFileException($"Couldn't find file under '{path}'");
    }
}