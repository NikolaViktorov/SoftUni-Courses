using Logger.Appenders;
using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using Logger.Assets.Files;
using Logger.Assets.Layouts;
using System;
using System.Collections.Generic;
using System.Text;
using Logger.Assets.Loggers;
using Logger.Factories;

namespace Logger.Core
{
    public class Engine
    {
        ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            errorFactory = new ErrorFactory();
        }

        internal void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorData = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string level = errorData[0];
                string date = errorData[1];
                string message = errorData[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(logger.ToString());
        }
    }
}
