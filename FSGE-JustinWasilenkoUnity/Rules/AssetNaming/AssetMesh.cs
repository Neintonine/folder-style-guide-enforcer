namespace FSGE_JustinWasilenkoUnity.Rules;

public class AssetMesh: AssetRule
{
    protected override string[] FileExtensions { get; } = new[] { "obj", "glb", "fbx" };
    protected override string[] Prefixes { get; } = new[] { "CH_", "VH_", "VP_", "SM_", "SK_", "SKEL_", "RIG_" };

    public override string GetInternalName()
    {
        return base.GetInternalName() + "mesh";
    }
}