namespace FSGE_JustinWasilenkoUnity.Rules.Rendering;

public sealed class URPAsset: RenderingAsset
{
    protected override string ScriptLine { get; } =
        "m_Script: {fileID: 11500000, guid: bf2edee5c58d82540a51f03df9d42094, type: 3}";

    protected override string[] Prefixes { get; } = { "URP_" };
    protected override string? FileType { get; } = "URP Asset";
}