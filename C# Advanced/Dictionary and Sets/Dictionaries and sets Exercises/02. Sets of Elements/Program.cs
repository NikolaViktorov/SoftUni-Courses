using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstSetLen = input[0];
            int secondSetLen = input[1];

            HashSet<int> firstNums = new HashSet<int>();
            HashSet<int> secondNums = new HashSet<int>();


            for (int i = 0; i < firstSetLen; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstNums.Add(num);
            }

            for (int i = 0; i < secondSetLen; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondNums.Add(num);
            }

            Console.WriteLine(string.Join(" ", firstNums.Intersect(secondNums)));
        }
    }
}
