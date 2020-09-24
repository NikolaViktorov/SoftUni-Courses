using Logger.Assets.Contracts;
using Logger.Core;
using Logger.Factories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();
            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Logger.Assets.Loggers.Logger(appenders);
            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelString = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelString = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelString);

                    appenders.Add(appender);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
