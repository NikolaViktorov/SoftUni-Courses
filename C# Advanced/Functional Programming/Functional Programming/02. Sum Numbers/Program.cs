using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        public static Func<string, int> parser = s => int.Parse(s);

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
