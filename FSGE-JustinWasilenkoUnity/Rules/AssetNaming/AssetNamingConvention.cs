using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public class AssetNamingConvention
{
    public static IEnumerable<RuleEntry> GetRules()
    {
        return new[]
        {
            new RuleEntry(new AssetMesh(), RuleResult.Error)
        };
    }
}