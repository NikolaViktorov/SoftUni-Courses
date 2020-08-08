using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> nums = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                if (isDevidable(i, deviders))
                {
                    nums.Add(i);
                }               
            }

            Console.WriteLine(string.Join(" ", nums));
        }

        static bool isDevidable(int n, int[] deviders)
        {
            bool isTrue = true;
            foreach (int divaider in deviders)
            {
                if (n % divaider != 0)
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
    }
}
