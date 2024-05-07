namespace FSGE_JustinWasilenkoUnity.Rules.Animations;

public sealed class AnimationOverrideController: AssetRule
{
    protected override string[] FileExtensions { get; } = { "overrideController" };
    protected override string[] Prefixes { get; } = { "AOC_" };
    protected override string? FileType { get; } = "Animation Override Controller";
}