using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Contracts
{
    public interface IEmployee
    {
        string Name { get; set; }
        string GetDetails();
    }
}
