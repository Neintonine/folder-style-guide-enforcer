using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public abstract class AssetRule : Rule
{
    protected abstract string[] FileExtensions { get; }
    protected abstract string[] Prefixes { get; }

    public override string GetInternalName()
    {
        return Constants.PREFIX + "/asset-";
    }

    public override string GetDescription()
    {
        string extensionString = String.Join(", ", FileExtensions);
        string prefixString = String.Join(", ", Prefixes);
        return $"Files with the extension of '{extensionString}' needs to have one of the following prefixes: {prefixString}";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        string extension = Path.GetExtension(context.RelativePath);
        
        foreach (string fileExtension in FileExtensions)
        {
            if (extension == $".{fileExtension}")
            {
                return true;
            }
        }

        return false;
    }

    public override bool IsValid(RuleCheckContext context)
    {
        string fileName = Path.GetFileName(context.RelativePath);

        foreach (var prefix in Prefixes)
        {
            if (fileName.StartsWith(prefix))
            {
                return true;
            }
        }

        return false;
    }
}