namespace FolderStyleGuideEnforcer.Rules;

public record RuleEntry(
    IRule rule,
    RuleResult result
)
{
    public IRule rule { get; } = rule;
    public RuleResult result { get; } = result;
}