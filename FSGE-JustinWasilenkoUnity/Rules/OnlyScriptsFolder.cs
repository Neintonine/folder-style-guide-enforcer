using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class OnlyScriptsFolder : Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/scripts-only-folder";
    }

    public override string GetDisplayName()
    {
        return "Scripts should only live in a 'Scripts'-folder";
    }

    public override string GetDescription()
    {
        return "see: https://github.com/justinwasilenko/Unity-Style-Guide?tab=readme-ov-file#2-project-structure";
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