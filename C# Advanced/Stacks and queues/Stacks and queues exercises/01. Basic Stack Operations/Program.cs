﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>( Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());


            int n = tokens[0];
            int s = tokens[1];
            int x = tokens[2];

            for (int i = 0; i < s; i++)
            {
                nums.Pop();
            }
            if (nums.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int smallestNum = nums.Min();

            while (nums.Count > 0)
            {
                if (nums.Pop() == x)
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            Console.WriteLine(smallestNum);
        }
    }
}
