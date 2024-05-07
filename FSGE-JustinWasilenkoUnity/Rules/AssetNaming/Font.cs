namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class Font : AssetRule
{
    protected override string[] FileExtensions { get; } = { "otf", "ttf" };
    protected override string[] Prefixes { get; } = { "Font_" };

    protected override string? FileType { get; } = "Font";
}