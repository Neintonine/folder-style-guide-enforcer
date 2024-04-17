// See https://aka.ms/new-console-template for more information

using FolderStyleGuideEnforcer;
using Spectre.Console.Cli;

CommandApp<CheckCommand> command = new CommandApp<CheckCommand>();
command.Run(args);