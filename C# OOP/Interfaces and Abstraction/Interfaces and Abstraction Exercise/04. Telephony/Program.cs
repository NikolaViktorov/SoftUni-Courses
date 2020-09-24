using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();
            List<string> sites = Console.ReadLine()
                .Split()
                .ToList();
            Smartphone smartphone = new Smartphone();

            numbers.ForEach(n => smartphone.Call(n));
            sites.ForEach(s => smartphone.Browse(s));
        }
    }
}
