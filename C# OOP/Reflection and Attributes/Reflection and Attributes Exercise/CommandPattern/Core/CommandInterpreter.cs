using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split().Skip(1).ToArray();
            string commandType = args.Split()[0];
            string result = null;
            if (commandType == "Hello")
            {
                ICommand command = new HelloCommand();
                result = command.Execute(commandArgs);
            }
            else if (commandType == "Exit")
            {
                ICommand command = new ExitCommand();
                result = command.Execute(commandArgs);
            }

            return result;
        }
    }
}