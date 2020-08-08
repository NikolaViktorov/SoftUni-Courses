using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        public delegate void Operator(List<int> nums);

        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        Calculator(nums, IncreaseNums);
                        break;
                    case "multiply":
                        Calculator(nums, MultiplyNums);
                        break;
                    case "subtract":
                        Calculator(nums, DecreaseNums);
                        break;
                    case "print":
                        Printer(nums);
                        break;
                }

                command = Console.ReadLine();
            }
        }
        static Action<List<int>> Printer = n => Console.WriteLine(string.Join(" ", n));
        public static void Calculator(List<int> nums, Operator opr)
        {
            opr(nums);
        }
        static void DecreaseNums(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i]--;
            }
        }
        static void IncreaseNums(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i]++;
            }
        }
        static void MultiplyNums(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] *= 2;
            }
        }
    }
}
