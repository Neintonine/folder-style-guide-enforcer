using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules.Rendering;

public abstract class RenderingAsset: AssetRule
{
    protected override string[] FileExtensions { get; } = { "asset" };

    protected abstract string ScriptLine { get; }
    
    
    public override bool AppliesTo(RuleCheckContext context)
    {
        if (!base.AppliesTo(context))
        {
            return false;
        }

        bool isAsset = File.ReadLines(context.AbsolutePath).Any(line => line.Trim() == ScriptLine);
        return isAsset;
    }
}