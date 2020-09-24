using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CommandPattern.Core.Commands
{
    public class HelloCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {string.Join(" ", args)}";
        }
    }
}
