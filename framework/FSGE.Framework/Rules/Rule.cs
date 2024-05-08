namespace FSGE.Framework.Rules;

public abstract class Rule : IRule
{
    public abstract string GetInternalName();

    public virtual string GetDisplayName()
    {
        return this.GetInternalName();
    }

    public virtual string GetDescription()
    {
        return this.GetDisplayName();
    }

    public abstract bool AppliesTo(RuleCheckContext context);

    public abstract bool IsValid(RuleCheckContext context);
}