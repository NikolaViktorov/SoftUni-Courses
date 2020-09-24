using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        const string datetimeFormat = "M/dd/yyyy h:mm:ss tt";
        private ILayout layout;
        private Level level;

        public ILayout Layout { get; private set; }

        public Level Level { get; set; }

        public int MessagesCount { get; private set; }

        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
            MessagesCount = 0;
        }

        public void Append(IError error)
        {
            string format = Layout.Format;

            DateTime timeOfOccurrence = error.TimeOfOccurrence;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format,
                timeOfOccurrence.ToString(datetimeFormat,
                CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);
            MessagesCount++;
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesCount}";
        }
    }
}
