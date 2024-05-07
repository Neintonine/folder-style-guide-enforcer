using System.Text.RegularExpressions;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class NoRedundantFolders: Rule
{
    private Regex _regex;
    
    public NoRedundantFolders()
    {
        this._regex = new Regex("(Assets|Meshes|Textures|Materials)");
    }
    
    public override string GetInternalName()
    {
        return Constants.PREFIX + "/no-redundant-folders";
    }

    public override string GetDisplayName()
    {
        return "Folders like Assets, Meshes, Textures, etc. are redundant";
    }

    public override string GetDescription()
    {
        return
            "see: https://github.com/justinwasilenko/Unity-Style-Guide?tab=readme-ov-file#26-do-not-create-folders-called-assets-or-assettypes";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return true;
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return !this._regex.IsMatch(context.RelativePath);
    }
}