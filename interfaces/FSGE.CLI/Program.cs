using FSGE.CLI.Commands;
using FSGE.CLI.Commands.Config;
using Spectre.Console.Cli;
using InstallCommand = FSGE.CLI.Commands.Plugins.InstallCommand;
using ListCommand = FSGE.CLI.Commands.Plugins.ListCommand;

CommandApp command = new CommandApp();

command.Configure(config =>
{
    config.PropagateExceptions();

    config.AddCommand<CheckCommand>("check");

    config.AddBranch("plugins", configurator =>
    {
        configurator.AddCommand<InstallCommand>("install");
        configurator.AddCommand<ListCommand>("list");
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

command.Run(args);