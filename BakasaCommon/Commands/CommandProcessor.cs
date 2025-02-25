using System;
using System.Text.RegularExpressions;

namespace BakasaCommon.Commands
{
    public static class CommandProcessor
    {
        public static Command ProcessCommand(string command)
        {
            // Extract command name
            Match match = Regex.Match(command, @"(\w+)\((.*)\)");
            if (!match.Success)
            {
                Console.WriteLine("Invalid command format.");
                return null;
            }

            string commandName = match.Groups[1].Value;
            string[] parameters = match.Groups[2].Value.Split(new string[] { "\", \"" }, StringSplitOptions.None);

            // Remove extra quotes
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim('"');
            }
            return new Command(commandName, parameters?.ToList());
        }
    }

}
