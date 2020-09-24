using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Assets.Contracts
{
    public interface IDirectoryManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        void FileAndDirectoryExist();
        string GetCurrentPath();
    }
}
