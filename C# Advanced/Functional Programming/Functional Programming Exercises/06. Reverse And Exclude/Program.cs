using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Action<List<int>> reverse = number => number.Reverse();
            reverse(nums);

            int n = int.Parse(Console.ReadLine());

         Predicate<int> isDivisible = num => num % n == 0;

                nums = nums
                .Where(num => !isDivisible(num))
                .ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
