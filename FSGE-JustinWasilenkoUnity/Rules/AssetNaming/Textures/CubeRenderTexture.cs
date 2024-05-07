using System.Xml;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class CubeRenderTexture: AssetRule
{
    protected override string[] FileExtensions { get; } = new[] { "asset", "renderTexture" };
    protected override string[] Prefixes { get; } = new[] { "RTC_" };
    
    protected override string? FileType { get; } = "Cube Render Texture";

    private const string DIMENSION = "4";

    public override bool AppliesTo(RuleCheckContext context)
    {
        if (!base.AppliesTo(context))
        {
            return false;
        }
        
        bool isRenderTexture = false;
        foreach (string line in File.ReadLines(context.AbsolutePath))
        {
            string trimmedLine = line.Trim();
            if (trimmedLine is "RenderTexture:" or "CustomRenderTexture:")
            {
                isRenderTexture = true;
            }

            if (!isRenderTexture)
            {
                continue;
            }
            
            if (!trimmedLine.StartsWith("m_Dimension"))
            {
                continue;
            }

            return trimmedLine.EndsWith(CubeRenderTexture.DIMENSION);
        }

        return false;
    }
}