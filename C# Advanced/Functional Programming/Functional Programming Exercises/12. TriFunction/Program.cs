using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Console.WriteLine(names.Find(p => isBigEnough(p, length)));
        }

        static Func<string, int, bool> isBigEnough = (name, length) =>
        {
            bool enough = false;

            if (SumOfLetters(name) > length)
            {
                enough = true;
            }
            return enough;
        };

        static Func<string, int> SumOfLetters = name =>
        {
            int sum = 0;
            foreach (var letter in name)
            {
                sum += letter;
            }
            return sum;
        };
    }
}
