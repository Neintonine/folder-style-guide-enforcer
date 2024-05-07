using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules.Materials;

public sealed class MaterialInstance : Material
{
    protected override string[] Prefixes { get; } = { "MI_" };

    protected override string? FileType { get; } = "Material Instance";

    private const string LINE_CHECK = "  m_Parent: {fileID: 0}";
    
    public override bool AppliesTo(RuleCheckContext context)
    {
        if (!base.AppliesTo(context))
        {
            return false;
        }
        
        bool isInstance = File.ReadLines(context.AbsolutePath).All(line => line.TrimEnd() != MaterialInstance.LINE_CHECK);
        return isInstance;
    }
}