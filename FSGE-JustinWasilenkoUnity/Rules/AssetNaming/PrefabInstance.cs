using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class PrefabInstance: AssetRule
{
    protected override string[] FileExtensions { get; } = { "prefab" };
    protected override string[] Prefixes { get; } = { "I" };

    protected override string? FileType { get; } = "Prefab Instance";

    private const string LINE_CHECK = "PrefabInstance:";

    public override string GetDescription()
    {
        return "Prefab instances need to start with 'I'.";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return base.AppliesTo(context) && File.ReadLines(context.AbsolutePath).Any(
            line => line.TrimEnd() == PrefabInstance.LINE_CHECK
        );
    }
}