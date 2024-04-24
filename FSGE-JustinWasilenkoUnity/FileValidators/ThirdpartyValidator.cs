using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.FileValidators;

public sealed class ThirdpartyValidator: IFileValidator
{
    public string GetInternalName()
    {
        return Constants.PREFIX + "/ignore-thirdparty";
    }

    public bool IsValid(RuleCheckContext ruleCheckContext)
    {
        return !ruleCheckContext.RelativePath.Contains("Thirdparty");
    }
}