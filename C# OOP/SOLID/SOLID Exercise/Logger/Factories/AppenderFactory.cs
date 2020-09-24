using Logger.Appenders;
using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using Logger.Assets.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (hasParsed == false)
            {
                throw new InvalidCastException("Invalid Level");
            }

            ILayout layout = layoutFactory.GetLayout(layoutType);
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException("Invalid Appender Type");
            }

            return appender;
        }

    }
}
