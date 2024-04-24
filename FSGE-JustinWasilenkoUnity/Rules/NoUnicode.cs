using System.Text.RegularExpressions;
using FolderStyleGuideEnforcer.Rules;

namespace FSGE_JustinWasilenkoUnity.Rules;

public sealed class NoUnicode : Rule
{
    private Regex _regex;

    public NoUnicode()
    {
        this._regex = new Regex($@"[A-Za-z.0-9\\ _]");
    }

    public override string GetInternalName()
    {
        return Constants.PREFIX + "/no-unicode";
    }

    public override bool AppliesTo(RuleCheckContext context)
    {
        return true;
    }

    public override bool IsValid(RuleCheckContext context)
    {
        return this._regex.Replace(context.RelativePath, "").Length < 1;
    }
}