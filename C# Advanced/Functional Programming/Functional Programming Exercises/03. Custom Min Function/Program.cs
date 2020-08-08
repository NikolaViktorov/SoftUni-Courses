using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> GetSmallestNum = n =>
            {
                int min = int.MaxValue;

                foreach (int num in n)
                {
                    if (min > num)
                    {
                        min = num;
                    }
                }

                return min;
            };

            Console.WriteLine(GetSmallestNum(nums));
        }
    }
}
