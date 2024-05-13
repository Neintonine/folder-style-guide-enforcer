// See https://aka.ms/new-console-template for more information

using FSGE.CLI.Commands;
using FSGE.CLI.Commands.Plugins;
using Spectre.Console.Cli;
using InstallCommand = FSGE.CLI.Commands.Plugins.InstallCommand;

CommandApp command = new CommandApp();

command.Configure(config =>
{
    config.PropagateExceptions();

    config.AddCommand<CreateCommand>("create")
        .WithDescription("Creates an empty config in the current directory.");

    config.AddCommand<CheckCommand>("check");

    config.AddBranch("plugins", configurator =>
    {
        configurator.AddCommand<InstallCommand>("install");
        configurator.AddCommand<ListCommand>("list");
    });
});

command.Run(args);