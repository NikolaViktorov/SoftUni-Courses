using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] nums = new long[size][];
            int cols = 1;

            for (int row = 0; row < size; row++)
            {
                nums[row] = new long[cols];
                nums[row][0] = 1;
                nums[row][cols - 1] = 1;

                if (cols > 2)
                {
                    long[] numsInPrevRow = nums[row - 1];
                    for (int col = 1; col < cols - 1; col++)
                    {
                        nums[row][col] = numsInPrevRow[col] + numsInPrevRow[col - 1];
                    }
                }
                cols++;
            }

            foreach (long[] arr in nums)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
