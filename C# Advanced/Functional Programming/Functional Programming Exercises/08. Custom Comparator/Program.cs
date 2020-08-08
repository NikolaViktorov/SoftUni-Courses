using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            nums = Sort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }

        static Func<List<int>, List<int>> Sort = nums =>
        {
            nums = nums.OrderBy(n => n)
            .ToList();
            List<int> odd = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    odd.Add(nums[i]);
                    nums.Remove(nums[i]);
                    i--;
                }
            }
            foreach (var num in odd)
            {
                nums.Add(num);
            }
            return nums;
        };

    }
}
