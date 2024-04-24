﻿using FolderStyleGuideEnforcer.FileValidator;
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
            return new[]
            {
                new RuleEntry(new CamelCase(), RuleResult.Error),
                new RuleEntry(new NoSpaces(), RuleResult.Error),
                new RuleEntry(new NoUnicode(), RuleResult.Error),
                new RuleEntry(new SceneInLevelFolder(), RuleResult.Error),
                new RuleEntry(new NoRedundantFolders(), RuleResult.Error),
                new RuleEntry(new ScriptsCorrectFolder(), RuleResult.Error),
                new RuleEntry(new OnlyScriptsFolder(), RuleResult.Error)
            };
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