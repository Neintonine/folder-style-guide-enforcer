using FSGE.Framework.FileValidator;
using FSGE.Framework.Repository;
using FSGE.Framework.Rules;

namespace FSGE.Framework.Ruleset;

public interface IRuleset : INamedDiscoverable
{
    public IReadOnlyCollection<RuleEntry> GetRules();
    public IReadOnlyCollection<IFileValidator> GetValidators();
}