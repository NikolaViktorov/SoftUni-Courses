using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int desiredLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            //PrintDesiredNames(desiredLength, names);
            PrintDesiredNames(names, desiredLength);
        }

        static Action<List<string>, int> PrintDesiredNames = (names, length) =>
        {
            foreach (var name in names)
            {
                if (name.Length <= length)
                {
                    Console.WriteLine(name);
                }
            }
        };

        //static void PrintDesiredNames(int length, List<string> names)
        //{
        //    foreach (var name in names)
        //    {
        //        if (name.Length <= length)
        //        {
        //            Console.WriteLine(name);
        //        }
        //    }
        //}
    }
}
