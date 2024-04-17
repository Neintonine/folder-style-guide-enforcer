using System.ComponentModel;
using FolderStyleGuideEnforcer.FileProviders;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FolderStyleGuideEnforcer;

internal class CheckCommand : Command<CheckCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Path to check")]
        [CommandOption("-d|--dir")]
        public string? Directory { get; init; }
        
        [CommandOption("-v|--verbose")]
        [DefaultValue(false)]
        public bool Verbose { get; init; }
    }
    
    public override int Execute(CommandContext context, Settings settings)
    {
        IEnumerable<string> provider = new FileProviderFactory().Get(settings);

        int count = provider.Count();
        AnsiConsole.Progress()
            .AutoRefresh(false) // Turn off auto refresh
            .AutoClear(false)   // Do not remove the task list when done
            .Columns(new TaskDescriptionColumn(), new ProgressBarColumn(), new PercentageColumn(), new SpinnerColumn())
            .Start(ctx =>
            {
                ProgressTask task = ctx.AddTask("Checking files...", maxValue: count);

                foreach (string path in provider)
                {
                    Task.Delay(2000);
                    task.Increment(1);
                }
            });

        return 0;
    }
}