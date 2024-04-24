using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class SceneInLevelFolder: Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/scene-in-levels-folder";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return context.RelativePath.EndsWith(".unity");
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return context.RelativePath.Contains($"{Path.DirectorySeparatorChar}Levels{Path.DirectorySeparatorChar}");
    }

}