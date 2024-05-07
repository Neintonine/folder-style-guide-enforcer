using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Rules;
using FolderStyleGuideEnforcer.Ruleset;
using FSGE_JustinWasilenkoUnity.FileValidators;
using FSGE_JustinWasilenkoUnity.Rules;

namespace FSGE_JustinWasilenkoUnity
{
    public sealed class UnityRuleset : Ruleset 
    {
        public override string GetInternalName()
        {
            return Constants.PREFIX;
        }

        public override string GetDisplayName()
        {
            return "Sets rules to implement the Unity Style Guide from justinwasilenko";
        }

        public override IReadOnlyCollection<RuleEntry> GetRules()
        {
            List<RuleEntry> rules = new List<RuleEntry>()
            {
                new RuleEntry(new PascalCase(), RuleResult.Error),
                new RuleEntry(new NoSpaces(), RuleResult.Error),
                new RuleEntry(new NoUnicode(), RuleResult.Error),
                new RuleEntry(new SceneInLevelFolder(), RuleResult.Error),
                new RuleEntry(new NoRedundantFolders(), RuleResult.Error),
                new RuleEntry(new OnlyScriptsFolder(), RuleResult.Error)
            };

            rules.AddRange(AssetNamingConvention.GetRules());
            
            return rules;
        }

        public override IReadOnlyCollection<IFileValidator> GetValidators()
        {
            return new IFileValidator[]
            {
                new MetaValidator(),
                new ThirdpartyValidator()
            };
        }
    }
}