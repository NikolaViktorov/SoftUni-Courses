using Logger.Assets.Contracts;
using Logger.Assets.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        const string datetimeFormat = "M/dd/yyyy h:mm:ss tt";
        private ILayout layout;
        private Level level;
        private IFile file;

        public ILayout Layout { get; private set; }

        public Level Level { get; set; }

        public int MessagesCount { get; private set; }

        public IFile File { get; private set; }

        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
            this.MessagesCount = 0;
        }

        public void Append(IError error)
        {
            string formattedMessage = File.Write(Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path,
                formattedMessage);
            MessagesCount++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesCount} File size: {this.File.Size}";
        }
    }
}
