using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string result = commandInterpreter.Read(input);
                if (result == null)
                {
                    Environment.Exit(1);
                }
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
