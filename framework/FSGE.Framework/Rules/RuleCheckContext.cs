namespace FSGE.Framework.Rules;

public record RuleCheckContext(
    string RelativePath,
    string AbsolutePath
)
{
    public string RelativePath { get; } = RelativePath;
    public string AbsolutePath { get; } = AbsolutePath;
}