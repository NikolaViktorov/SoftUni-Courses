using P03.Detail_Printer.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> docs = new List<string>();
            IEmployee employee = new Employee("PESHO");
            IEmployee manager = new Manager("gosho", docs);
            List<IEmployee> employees = new List<IEmployee>()
            {
                employee,
                manager
            };

            DetailsPrinter detailPrinter = new DetailsPrinter(employees);

            detailPrinter.PrintDetails();
        }
    }
}
