using FSGE.CLI.Commands;
using FSGE.CLI.Commands.Config;
using Spectre.Console.Cli;
using InstallCommand = FSGE.CLI.Commands.Plugins.InstallCommand;
using ListCommand = FSGE.CLI.Commands.Plugins.ListCommand;

CommandApp command = new CommandApp();

command.Configure(config =>
{
    config.AddCommand<CheckCommand>("check")
        .WithDescription("Checks the current working directory against a set of rules specified in a '.fsge-config'.")
        .WithExample("check", "--dir PATHTODIRECTORY")
        .WithExample("check",  "--config PATHTOCONFIG");

    config.AddBranch("plugins", configurator =>
    {
        configurator.SetDescription("Offers tools to manage plugins");
        
        configurator.AddCommand<InstallCommand>("install")
            .WithDescription("Installs a plugin");
        configurator.AddCommand<ListCommand>("list")
            .WithDescription("Lists available plugins");
    });

    config.AddBranch("config", branchConfig =>
    {
        branchConfig.SetDescription("Offers tools to manage configurations.");

        branchConfig.AddCommand<CreateCommand>("create")
            .WithDescription("Creates an empty config in the current directory.");

        branchConfig.AddCommand<FSGE.CLI.Commands.Config.ListCommand>("list")
            .WithDescription("Lists the available presets.");
    });
});

return command.Run(args);