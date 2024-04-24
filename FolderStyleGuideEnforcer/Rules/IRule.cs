using FolderStyleGuideEnforcer.Repository;

namespace FolderStyleGuideEnforcer.Rules;

public interface IRule : INamedDiscoverable
{
    public bool AppliesTo(RuleCheckContext context);
    public bool IsValid(RuleCheckContext context);
}