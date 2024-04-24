// See https://aka.ms/new-console-template for more information

using FSGE_CLI;
using Spectre.Console.Cli;

CommandApp<CheckCommand> command = new CommandApp<CheckCommand>();

command.Configure(config =>
{
    config.PropagateExceptions();
});

command.Run(args);