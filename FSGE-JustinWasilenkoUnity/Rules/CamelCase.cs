using System.Text.RegularExpressions;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules
{
    public sealed class CamelCase : Rule
    {
        private static string[] DELIMITERS = new string[]
        {
            "_", "\\\\", "\\/", " "
        };

        private Regex _regex;
        
        public CamelCase()
        {
            string delimiters = String.Join("", CamelCase.DELIMITERS);
            this._regex = new Regex($"([{delimiters}][a-z])");
        }
        
        public override string GetInternalName()
        {
            return $"{Constants.PREFIX}/camel-case";
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