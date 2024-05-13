using System.ComponentModel;
using System.Net;
using System.Text;
using FSGE.Framework.Plugins;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FSGE.CLI.Commands.Plugins;

public sealed class InstallCommand: AsyncCommand<InstallCommand.Settings>
{
    private static string[] _allowedHttpSchemes = ["http", "https"];

    public class Settings: CommandSettings
    {
        [CommandArgument(0, "<path>")]
        [Description("Specifies the path where the file should install from. It can be an HTTP link, which will result in downloading the file.")]
        public string Path { get; init; }
        
        [CommandArgument(1, "[targetPluginPath]")]
        [Description("Specifies the path the file should install to. This can be used, if you use different plugin folders.")]
        public string? Target { get; init; }
        
        [CommandOption("-y|--yes")]
        public bool AutomaticYes { get; init; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        Uri uri = new Uri(settings.Path);
        string targetPath = settings.Target ?? new PluginConfigurator().GetDefaultPath();

        if (uri.IsFile)
        {
            return this.ExecuteFileInstall(uri, targetPath, settings);
        }

        if (InstallCommand._allowedHttpSchemes.Contains(uri.Scheme))
        {
            return await this.ExecuteDownloadInstall(uri, targetPath, settings);
        }
        
        return 0;
    }

    private async Task<int> ExecuteDownloadInstall(Uri uri, string targetPath, Settings settings)
    {
        string filename = uri.Segments.Last();
        string targetFilePath = Path.Combine(targetPath, filename);
        
        StringBuilder builder = new();
        builder.Append($"Are you sure, you want to download '{filename}' from '{uri.AbsoluteUri}' to '{targetPath}'?");

        if (File.Exists(targetFilePath))
        {
            builder.Append(" This will override the existing file!");
        }

        if (!settings.AutomaticYes &&
            !AnsiConsole.Confirm(builder.ToString())
           )
        {
            return 0;
        }

        await AnsiConsole.Progress().StartAsync(async ctx =>
        {
            var task = ctx.AddTask($"[green]Downloading '{uri.AbsoluteUri}'[/]");
            
            using WebClient client = new WebClient();
            client.DownloadProgressChanged += (sender, args) =>
            {
                task.Value = args.BytesReceived;
                task.MaxValue = args.TotalBytesToReceive;
            };
            
            await client.DownloadFileTaskAsync(uri, targetFilePath);
        });

        return 0;
    }

    private int ExecuteFileInstall(Uri uri, string targetPath, Settings settings)
    {
        string filename = uri.Segments.Last();
        string targetFilePath = Path.Combine(targetPath, filename);
        
        StringBuilder builder = new();
        builder.Append($"Are you sure, you want to install '{filename}' to '{targetPath}'?");

        if (File.Exists(targetFilePath))
        {
            builder.Append(" This will override the existing file!");
        }

        if (!settings.AutomaticYes &&
            !AnsiConsole.Confirm(builder.ToString())
           )
        {
            return 0;
        }

        FileInfo from = new FileInfo(uri.LocalPath);
        from.CopyTo(targetFilePath, true);

        return 0;
    }

}