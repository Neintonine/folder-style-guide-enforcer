namespace FSGE_JustinWasilenkoUnity.Rules.Animations;

public sealed class Animation: AssetRule
{
    protected override string[] FileExtensions { get; } = { "anim" };
    protected override string[] Prefixes { get; } = { "A_" };

    protected override string? FileType { get; } = "Animation";
}