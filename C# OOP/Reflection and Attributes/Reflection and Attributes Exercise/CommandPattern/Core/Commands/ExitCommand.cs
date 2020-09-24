using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            return null; 
        }
    }
}
