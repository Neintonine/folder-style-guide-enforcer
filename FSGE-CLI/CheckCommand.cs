using System.ComponentModel;
using System.Reflection;
using FolderStyleGuideEnforcer;
using FolderStyleGuideEnforcer.Configuration;
using FolderStyleGuideEnforcer.FileProviders;
using FolderStyleGuideEnforcer.FileValidator;
using FolderStyleGuideEnforcer.Plugins;
using FolderStyleGuideEnforcer.Rules;
using FolderStyleGuideEnforcer.Ruleset;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FSGE_CLI;

internal class CheckCommand : AsyncCommand<CheckCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Path to check")]
        [CommandOption("-d|--dir")]
        public string? Directory { get; init; }

        [Description("Path to configuration")]
        [CommandOption("-c|--config")]
        public string? ConfigurationPath { get; init; }
        
        [Description("Path to the plugin directory")]
        [CommandOption("--pluginDir")]
        public string? PluginDirectory { get; init; }

        [CommandOption("-v|--verbose")]
        [DefaultValue(false)]
        public bool Verbose { get; init; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        IProvider provider = new FileProviderFactory().Get(settings);

        Configuration config = this.GetConfiguration(settings);

        Dictionary<string, RuleChecker.Result> results = new();
        int count = provider.Count();

        string? directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (directory == null)
        {
            throw new Exception("Couldn't find directory for plugins");
        }
        
        PluginHandler pluginHandler = new PluginHandler(settings.PluginDirectory ?? Path.Combine(directory, "plugins"));
        
        await AnsiConsole.Progress()
            .AutoRefresh(true) // Turn off auto refresh
            .AutoClear(false) // Do not remove the task list when done
            .Columns(new TaskDescriptionColumn(), new ProgressBarColumn(), new PercentageColumn(), new SpinnerColumn())
            .StartAsync(async ctx =>
            {
                RulesetRepository rulesetRepository = new RulesetRepository();
                RuleRepository rules = new RuleRepository();
                FileValidatorRepository fileValidatorRepository = new FileValidatorRepository();

                ProgressTask discoveryTask = ctx.AddTask("Discovering rules and rulesets...", maxValue: 3);

                IReadOnlyList<Plugin> plugins = pluginHandler.DiscoverPlugins(true);

                rulesetRepository.Discover(plugins);
                IReadOnlyCollection<IRuleset> rulesets = rulesetRepository.GetFromConfiguration(config);
                discoveryTask.Increment(1);

                RuleChecker checker = new RuleChecker();
                discoveryTask.Increment(1);

                ProgressTask task = ctx.AddTask("Checking files...", maxValue: count);
                
                foreach (string path in provider)
                {
                    RuleCheckContext context = new RuleCheckContext(
                        path,
                        provider.GetAbsolutePath(path)
                    );

                    RuleChecker.Result result = checker.Check(context, rulesets);
                    results.Add(path, result);

                    task.Increment(1);
                }
            });

        Tree tree = this.GetTreeFromResults(results);
        AnsiConsole.Write(tree);
        
        return 0;
    }

    private Tree GetTreeFromResults(Dictionary<string,RuleChecker.Result> results)
    {
        Tree root = new Tree("Results");
        foreach (KeyValuePair<string,RuleChecker.Result> result in results)
        {
            if (!result.Value.HasAnyResults())
            {
                continue;
            }
            
            TreeNode pathNode = root.AddNode(result.Key);

            foreach (IRule valueError in result.Value.Errors)
            {
                pathNode.AddNode($"[red]{valueError.GetDisplayName()} - {valueError.GetDescription()}[/]");
            }
            foreach (IRule valueError in result.Value.Warnings)
            {
                pathNode.AddNode($"[yellow]{valueError.GetDisplayName()} - {valueError.GetDescription()}[/]");
            }
            foreach (IRule valueError in result.Value.Infos)
            {
                pathNode.AddNode($"[blue]{valueError.GetDisplayName()} - {valueError.GetDescription()}[/]");
            }
        }

        return root;
    }

    private Configuration GetConfiguration(Settings settings)
    {
        ConfigurationHandler handler = new ConfigurationHandler();
        if (settings.ConfigurationPath != null)
        {
            return handler.GetFromFile(settings.ConfigurationPath);
        }

        return handler.GetFromDirectory(settings.Directory ?? Directory.GetCurrentDirectory());
    }
}