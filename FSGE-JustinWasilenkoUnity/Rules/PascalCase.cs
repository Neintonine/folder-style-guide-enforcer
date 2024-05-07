using System.Text.RegularExpressions;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules
{
    public sealed class PascalCase : Rule
    {
        private static string[] DELIMITERS = new string[]
        {
            "_", "\\\\", "\\/", " "
        };

        private Regex _regex;
        
        public PascalCase()
        {
            string delimiters = String.Join("", PascalCase.DELIMITERS);
            this._regex = new Regex($"([{delimiters}][a-z])");
        }
        
        public override string GetInternalName()
        {
            return $"{Constants.PREFIX}/camel-case";
        }

        public override string GetDisplayName()
        {
            return "Filenames and Directories should be pascal case";
        }

        public override string GetDescription()
        {
            return "see: https://github.com/justinwasilenko/Unity-Style-Guide?tab=readme-ov-file#always-use-pascalcase";
        }

        public override bool AppliesTo(RuleCheckContext context)
        {
            return true;
        }

        public override bool IsValid(RuleCheckContext context)
        {
            return !this._regex.IsMatch(context.RelativePath);
        }
    }
}