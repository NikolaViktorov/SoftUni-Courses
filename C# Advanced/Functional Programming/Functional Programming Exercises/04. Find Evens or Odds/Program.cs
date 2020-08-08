using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string oddOrEven = Console.ReadLine();

            int start = nums[0];
            int end = nums[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            if (oddOrEven == "odd")
            {
                numbers = numbers.Where(n => isOdd(n)).ToList();
            }
            else if (oddOrEven == "even")
            {
                numbers = numbers.Where(n => isEven(n)).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

    }
}
