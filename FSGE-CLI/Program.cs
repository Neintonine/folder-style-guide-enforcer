// See https://aka.ms/new-console-template for more information

using FSGE_CLI;
using Spectre.Console.Cli;

CommandApp command = new CommandApp();

command.Configure(config =>
{
    config.PropagateExceptions();

    config.AddCommand<CreateCommand>("create")
        .WithDescription("Creates an empty config in the current directory.");

    config.AddCommand<CheckCommand>("check");

    config.AddCommand<InstallCommand>("install")
        .WithDescription("Installs this software as a user.");
});

command.Run(args);