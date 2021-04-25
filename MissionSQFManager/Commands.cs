using System;
using System.Collections.Generic;

namespace MissionSQFManager
{
    public static class Commands
    {
        private static List<Command> commands = new List<Command>();

        public static void RegisterCommands()
        {
            Command help = new Command("Help", "Help menu", "Displays the help menu.");
            help.onCommand += () => { DisplayHelp(); };

            Command clearConsole = new Command("Clear", "Clear console", "Clears the inputs in the console window.");
            clearConsole.onCommand += () => { Console.Clear(); DisplayHelp(); };

            Command exit = new Command("Exit", "Exit", "Exits the program.");
            exit.onCommand += () => { Environment.Exit(0); };

            Command.WhiteSpace();

            Command replaceClassnames = new Command("0", "Replace classnames", "Replaces editor classnames with lootable classnames.");
            replaceClassnames.onCommand += SQFClassNameCorrector.ReplaceClassNamesOfInputFiles;

            Command formatCode = new Command("1", "Format code", "Formats and compacts the code.");
            formatCode.onCommand += SQFFormatter.FormatInputFiles;

            Command biediConvert = new Command("2", "Convert to biedi", "Converts a .SQF file to a .biedi file.");
            biediConvert.onCommand += SQFToBiediConverter.ConvertInputsToBiedi;
        }

        public static void AddCommand(Command command) => commands.Add(command);

        public static void DisplayHelp()
        {
            foreach (Command command in commands)
            {
                if (string.IsNullOrEmpty(command.name))
                {
                    Console.WriteLine("");
                    continue;
                }

                Console.WriteLine($"Type \"{command.inputTrigger}\" to {command.name}: {command.description}");
            }
            Console.WriteLine("");
        }

        public static void CallCommand(string input)
        {
            Command command = null;

            foreach (Command curCommand in commands)
            {
                if (input.Equals(curCommand.inputTrigger, StringComparison.InvariantCultureIgnoreCase))
                {
                    command = curCommand;
                    break;
                }
            }

            if (command != null)
            {
                command.onCommand();
            }
            else
            {
                Utils.WriteError("Input was invald!");
            }
        }
    }

    public class Command
    {
        public Command(string inputTrigger, string name, string description)
        {
            this.inputTrigger = inputTrigger;
            this.name = name;
            this.description = description;

            Commands.AddCommand(this); //Add command to the list of commands
        }

        private Command() => Commands.AddCommand(this); //Add an empty command

        public string inputTrigger;
        public string name;
        public string description;

        public Action onCommand;

        public static void WhiteSpace() => new Command();
    }
}
