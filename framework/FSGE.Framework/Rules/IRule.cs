using FSGE.Framework.Repository;

namespace FSGE.Framework.Rules;

public interface IRule : INamedDiscoverable
{
    public bool AppliesTo(RuleCheckContext context);
    public bool IsValid(RuleCheckContext context);
}