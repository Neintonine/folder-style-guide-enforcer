namespace FSGE_JustinWasilenkoUnity.Rules.Audio;

public sealed class AudioMixer: AssetRule
{
    protected override string[] FileExtensions { get; } = { "mixer" };
    protected override string[] Prefixes { get; } = { "MIX_" };
    protected override string? FileType { get; } = "Audio Mixer";
}