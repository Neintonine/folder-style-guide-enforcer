using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class OnlyScriptsFolder : Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/scripts-only-folder";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return context.RelativePath.Contains("Scripts");
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return Path.GetExtension(context.RelativePath) == ".cs";
    }
}