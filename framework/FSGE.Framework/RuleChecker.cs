using FSGE.Framework.FileValidator;
using FSGE.Framework.Rules;
using FSGE.Framework.Ruleset;

namespace FSGE.Framework;

public class RuleChecker
{
    public class Result
    {
        private IList<IRule> _errors = new List<IRule>();
        private IList<IRule> _warnings = new List<IRule>();
        private IList<IRule> _infos = new List<IRule>();

        public IReadOnlyList<IRule> Errors => (IReadOnlyList<IRule>)this._errors;
        public IReadOnlyList<IRule> Warnings => (IReadOnlyList<IRule>)this._warnings;
        public IReadOnlyList<IRule> Infos => (IReadOnlyList<IRule>)this._infos;

        public void Add(IRule rule, RuleResult result)
        {
            switch (result)
            {
                case RuleResult.Error:
                    this._errors.Add(rule);
                    break;
                case RuleResult.Warning:
                    this._warnings.Add(rule);
                    break;
                case RuleResult.Info:
                    this._infos.Add(rule);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
        }

        public bool HasAnyResults()
        {
            if (this._errors.Count > 0)
            {
                return true;
            }

            if (this._warnings.Count > 0)
            {
                return true;
            }

            if (this._infos.Count > 0)
            {
                return true;
            }

            return false;
        }
    }

    public Result Check(RuleCheckContext context, IReadOnlyCollection<IRuleset> rulesets)
    {
        List<RuleEntry> rules = new List<RuleEntry>();

        foreach (IRuleset ruleset in rulesets)
        {
            IReadOnlyCollection<IFileValidator> validators = ruleset.GetValidators();
            if (!this.CheckValidators(context, validators))
            {
                continue;
            }

            IReadOnlyCollection<RuleEntry> ruleEntries = ruleset.GetRules();
            
            rules.AddRange(ruleEntries);
        }

        return this.Check(context, rules);
    }

    public Result Check(RuleCheckContext context, IReadOnlyCollection<RuleEntry> rules)
    {
        Result checkResult = new Result();
        foreach ((IRule? rule, RuleResult result) in rules)
        {
            if (this.CheckRule(context, rule))
            {
                continue;
            }

            checkResult.Add(rule, result);
        }

        return checkResult;
    }

    public RuleResult Check(RuleCheckContext context, RuleEntry rule)
    {
        bool check = this.CheckRule(context, rule.rule);

        if (check)
        {
            return RuleResult.NoError;
        }

        return rule.result;
    }

    private bool CheckRule(RuleCheckContext context, IRule rule)
    {
        if (!rule.AppliesTo(context))
        {
            return true;
        }

        return rule.IsValid(context);
    }
    private bool CheckValidators(RuleCheckContext ruleCheckContext, IReadOnlyCollection<IFileValidator> validators)
    {
        foreach (IFileValidator fileValidator in validators)
        {
            if (fileValidator.IsValid(ruleCheckContext))
            {
                continue;
            }

            return false;
        }

        return true;
    }
}