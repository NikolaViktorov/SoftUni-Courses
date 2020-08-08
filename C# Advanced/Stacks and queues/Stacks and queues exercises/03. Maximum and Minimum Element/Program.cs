using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] querie = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                switch (querie[0])
                {
                    case 1:
                        nums.Push(querie[1]);
                        break;
                    case 2:
                        if (nums.Count > 0)
                        {
                            nums.Pop();
                        }
                        break;
                    case 3:
                        if (nums.Count > 0)
                        {
                            PrintMax(nums);
                        }
                        break;
                    case 4:
                        if (nums.Count > 0)
                        {
                            PrintMin(nums);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", nums));

        }

        private static void PrintMin(Stack<int> nums)
        {
            
            int[] numsToAdd = new int[nums.Count];
            int i = 0;

            int max = nums.Pop();
            numsToAdd[i] = max;
            i++;

            while (nums.Count > 0)
            {
                int nextNum = nums.Pop();
                if (nextNum < max)
                {
                    max = nextNum;
                    numsToAdd[i] = max;
                    i++;
                }
                else
                {
                    numsToAdd[i] = nextNum;
                    i++;
                }
            }

            for (int j = numsToAdd.Length - 1; j >= 0; j--)
            {
                nums.Push(numsToAdd[j]);
            }
            Console.WriteLine(max);
        }

        private static void PrintMax(Stack<int> nums)
        {
            int[] numsToAdd = new int[nums.Count];
            int i = 0;

            int max = nums.Pop();
            numsToAdd[i] = max;
            i++;

            while (nums.Count > 0)
            {
                int nextNum = nums.Pop();
                if (nextNum  > max)
                {
                    max = nextNum;
                    numsToAdd[i] = max;
                    i++;
                }
                else
                {
                    numsToAdd[i] = nextNum;
                    i++;
                }
            }

            for (int j = numsToAdd.Length - 1; j >= 0; j--)
            {
                nums.Push(numsToAdd[j]);
            }
            Console.WriteLine(max);
            
        }
    }
}
