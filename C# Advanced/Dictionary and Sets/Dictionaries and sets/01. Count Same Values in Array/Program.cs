using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                double currNum = input[i];
                if (numbers.ContainsKey(currNum) == true)
                {
                    numbers[currNum]++;
                }
                else
                {
                    numbers.Add(currNum, 1);
                }
            }

            foreach (KeyValuePair<double, int> num in numbers)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
