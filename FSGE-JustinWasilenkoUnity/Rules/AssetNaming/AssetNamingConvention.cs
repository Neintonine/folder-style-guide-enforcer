using FolderStyleGuideEnforcer.Rules;
using FSGE_JustinWasilenkoUnity.Rules.Animations;
using FSGE_JustinWasilenkoUnity.Rules.Audio;
using FSGE_JustinWasilenkoUnity.Rules.Materials;
using FSGE_JustinWasilenkoUnity.Rules.Rendering;

namespace FSGE_JustinWasilenkoUnity.Rules;

public class AssetNamingConvention
{
    public static IEnumerable<RuleEntry> GetRules()
    {
        return new[]
        {
            new RuleEntry(new AssetMesh(), RuleResult.Error),
            
            new RuleEntry(new Animation(), RuleResult.Error),
            new RuleEntry(new AvatarMask(), RuleResult.Error),
            new RuleEntry(new AnimationOverrideController(), RuleResult.Error),
            new RuleEntry(new AnimationController(), RuleResult.Error),
            
            new RuleEntry(new PrefabInstance(), RuleResult.Error),
            
            new RuleEntry(new Material(), RuleResult.Error),
            new RuleEntry(new MaterialInstance(), RuleResult.Error),
            new RuleEntry(new PhysicsMaterial(), RuleResult.Error),
            new RuleEntry(new ShaderGraph(), RuleResult.Error),
            
            new RuleEntry(new AssetTexture(), RuleResult.Error),
            new RuleEntry(new RenderTexture(), RuleResult.Error),
            new RuleEntry(new CubeRenderTexture(), RuleResult.Error),
            
            new RuleEntry(new AudioClip(), RuleResult.Error),
            new RuleEntry(new AudioMixer(), RuleResult.Error),
            
            new RuleEntry(new HDRPAsset(), RuleResult.Error),
            new RuleEntry(new URPAsset(), RuleResult.Error)
        };
    }
}