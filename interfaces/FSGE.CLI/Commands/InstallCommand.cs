using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FSGE.CLI.Commands;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class InstallCommand: Command<InstallCommand.Settings>
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Settings: CommandSettings
    {
        [Description("Specifies, where the files should be installed to. Supports both absolute and relative paths.")]
        [CommandOption("--path")]
        public string? InstallPath { get; init; }
        
        [CommandOption("-y|--yes|-a|--allow")]
        [DefaultValue(false)]
        [Description("Allows the execution of the installer, without asking before executing it.")]
        public bool Allow { get; init; }
    }
    
    public override int Execute(CommandContext context, Settings settings)
    {
        string target = this.GetPath(settings.InstallPath);
        
        if (!settings.Allow && !AnsiConsole.Confirm($"Are you sure you want to install the software to: [green]{target}[/]"))
        {
            AnsiConsole.WriteLine("Install cancelled...");

            return 0;
        }

        string source = Path.GetFullPath(AppContext.BaseDirectory);
        if (source != target)
        {
            this.CopyApplication(source, target);
        }
        else
        {
            AnsiConsole.MarkupLine("[blue]Skipping copy step, since the target folder is the same as the source.[/]");
        }

        return 0;
    }

    private void CopyApplication(string source, string target)
    {
        Directory.CreateDirectory(target);
        
        foreach (string file in Directory.EnumerateFiles(source, "*.*"))
        {
            if (Path.GetExtension(file) is not ".exe" or ".dll")
            {
                continue;
            }

            FileInfo sourceInfo = new FileInfo(Path.GetFullPath(file, source));
            FileInfo targetInfo = new FileInfo(Path.GetFullPath(file, target));
            using FileStream readStream = sourceInfo.OpenRead();
            using FileStream writeStream = targetInfo.OpenWrite();
            
            readStream.CopyTo(writeStream);
        }
    }

    private string GetPath(string? settingsPath)
    {
        if (settingsPath == null)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FolderStyleGuideEnforcer");
        }

        if (Path.IsPathFullyQualified(settingsPath))
        {
            return settingsPath;
        }

        return Path.GetFullPath(settingsPath, Environment.CurrentDirectory);
    }
}