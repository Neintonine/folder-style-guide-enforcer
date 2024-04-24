using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class ScriptsCorrectFolder: Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/scripts-correct-folder";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return Path.GetExtension(context.RelativePath) == ".cs";
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return context.RelativePath.Contains("Scripts");
    }
}