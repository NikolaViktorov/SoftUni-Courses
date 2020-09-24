using Logger.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Assets.DirectoryManagers
{
    public class DirectoryManager : IDirectoryManager
    {
        string currentPath;
        string currentDirectory;
        string currentFile;

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        private DirectoryManager()
        {
            this.currentPath = this.GetCurrentPath();
        }
        public DirectoryManager(string currentDirectory, string currentFile) : this() 
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public void FileAndDirectoryExist()
        {
            if (Directory.Exists(this.CurrentDirectoryPath) == false)
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
