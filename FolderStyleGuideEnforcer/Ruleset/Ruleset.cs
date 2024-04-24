using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Rules;

namespace FolderStyleGuideEnforcer.Ruleset;

public abstract class Ruleset: IRuleset
{
    public abstract string GetInternalName();

    public virtual string GetDisplayName()
    {
        return this.GetInternalName();
    }

    public virtual string GetDescription()
    {
        return this.GetInternalName();
    }

    public abstract IReadOnlyCollection<RuleEntry> GetRules();
    
    public virtual IReadOnlyCollection<IFileValidator> GetValidators()
    {
        return new List<IFileValidator>();
    }
}