using Logger.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Loggers
{
    public class Logger : ILogger
    {
        ICollection<IAppender> appenders;

        public IReadOnlyCollection<IAppender> Appenders => 
            (IReadOnlyCollection<IAppender>)appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in Appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Logger info");

            foreach (var appender in this.Appenders)
            {
                builder.AppendLine(appender.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
