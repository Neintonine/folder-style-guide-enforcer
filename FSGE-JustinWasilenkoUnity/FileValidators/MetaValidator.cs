using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.FileValidators;

public sealed class MetaValidator: IFileValidator
{
    public string GetInternalName()
    {
        return Constants.PREFIX + "/meta-validator";
    }

    public bool IsValid(RuleCheckContext ruleCheckContext)
    {
        return !ruleCheckContext.RelativePath.EndsWith(".meta");
    }
}