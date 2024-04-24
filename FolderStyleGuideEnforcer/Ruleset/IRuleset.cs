using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Repository;
using FolderStyleGuideEnforcer.Rules;

namespace FolderStyleGuideEnforcer.Ruleset;

public interface IRuleset : INamedDiscoverable
{
    public IReadOnlyCollection<RuleEntry> GetRules();
    public IReadOnlyCollection<IFileValidator> GetValidators();
}