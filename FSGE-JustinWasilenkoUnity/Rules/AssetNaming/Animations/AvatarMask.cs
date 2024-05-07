namespace FSGE_JustinWasilenkoUnity.Rules.Animations;

public sealed class AvatarMask: AssetRule
{
    protected override string[] FileExtensions { get; } = { "mask" };
    protected override string[] Prefixes { get; } = new[] { "AM_" };
    protected override string? FileType { get; } = "Avatar Mask";
}