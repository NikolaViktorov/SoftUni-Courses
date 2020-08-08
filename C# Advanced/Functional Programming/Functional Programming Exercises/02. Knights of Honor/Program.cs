using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            for (int i = 0; i < names.Length; i++)
            {
                print(names[i]);
            }
        }
    }
}
