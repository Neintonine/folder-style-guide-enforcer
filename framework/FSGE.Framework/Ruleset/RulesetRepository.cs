using FSGE.Framework.Repository;

namespace FSGE.Framework.Ruleset;

public sealed class RulesetRepository : DiscoverableRepository<IRuleset>
{
    public IReadOnlyCollection<IRuleset> GetFromConfiguration(Configuration.Configuration config)
    {
        List<IRuleset> rulesets = new List<IRuleset>();
        
        foreach (string rulesetId in config.rulesets)
        {
            if (!this.Has(rulesetId))
            {
                continue;
            }

            IRuleset ruleset = this.Get(rulesetId);

            if (ruleset == null)
            {
                continue;
            }
            
            rulesets.Add(ruleset);
        }

        return rulesets;
    }
}