using FSGE.Framework.Repository;
using FSGE.Framework.Rules;

namespace FSGE.Framework.FileValidator;

public interface IFileValidator: IDiscoverable 
{
    public bool IsValid(RuleCheckContext ruleCheckContext);
}