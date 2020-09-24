using Logger.Assets.Contracts;
using Logger.Assets.DirectoryManagers;
using Logger.Assets .Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Assets.Files
{
    public class LogFile : IFile
    {
        const string datetimeFormat = "M/dd/yyyy h:mm:ss tt";
        const string currentDirectory = "\\logs\\";
        const string currentFile = "logs.txt";
        string currentPath;
        IDirectoryManager directoryManager;

        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        public LogFile()
        {
            directoryManager = new DirectoryManager(currentDirectory, currentFile);
            this.currentPath = this.directoryManager.GetCurrentPath();
            this.directoryManager.FileAndDirectoryExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);
            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime timeOfOccurrence = error.TimeOfOccurrence;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                timeOfOccurrence.ToString(datetimeFormat,
                CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            return formattedMessage;
        }
    }
}
