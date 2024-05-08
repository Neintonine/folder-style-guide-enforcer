namespace FSGE.Framework.Configuration;

public record Configuration(
    IReadOnlyList<string> rulesets,
    IReadOnlyDictionary<string, string> rules,
    IReadOnlyList<string> modifiers
)
{
    public IReadOnlyList<string> rulesets { get; } = rulesets;
    public IReadOnlyList<string> modifiers { get; } = modifiers;
    public IReadOnlyDictionary<string, string> rules { get; } = rules;
}