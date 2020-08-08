using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            ListyIterator<string> iterator = new ListyIterator<string>(input
                .Skip(1)
                .ToList());

            input = Console.ReadLine()
                .Split(' ');

            while (input[0] != "END")
            {
                string command = input[0];
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        iterator.Print();
                        break;
                    case "PrintAll":
                        iterator.PrintAll();
                        break;
                }

                input = Console.ReadLine()
                .Split(' ');
            }
        }
    }
}
