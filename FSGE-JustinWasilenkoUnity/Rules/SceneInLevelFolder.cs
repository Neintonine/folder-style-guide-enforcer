using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class SceneInLevelFolder: Rule
{
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/scene-in-levels-folder";
    }

    public override string GetDisplayName()
    {
        return "Scenes should only live in a 'Levels'-folders";
    }

    public override string GetDescription()
    {
        return "see: https://github.com/justinwasilenko/Unity-Style-Guide?tab=readme-ov-file#24-all-scene-files-belong-in-a-folder-called-levels";
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