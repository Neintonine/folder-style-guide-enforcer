using FolderStyleGuideEnforcer.Repository;
using FolderStyleGuideEnforcer.Rules;

namespace FolderStyleGuideEnforcer.FileValidator;

public interface IFileValidator: IDiscoverable 
{
    public bool IsValid(RuleCheckContext ruleCheckContext);
}