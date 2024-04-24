using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class NoSpaces: Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/no-spaces";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return true;
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return !context.RelativePath.Contains(' ');
    }
}