namespace FSGE_JustinWasilenkoUnity.Rules.Animations;

public sealed class AnimationController: AssetRule
{
    protected override string[] FileExtensions { get; } = { "controller" };
    protected override string[] Prefixes { get; } = { "AC_" };
    protected override string? FileType { get; } = "Animation Controller";
}