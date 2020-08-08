using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        private static int i;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] nums = new int[rows, cols];

            int[] numbersOnRow = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    nums[row, col] = numbersOnRow[col];
                }
            }
            int maxSum = int.MinValue;
            int[,] finalNums = new int[2, 2];

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currSum = nums[row, col] + nums[row + 1, col] 
                        + nums[row, col + 1] + nums[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        finalNums[0, 0] = nums[row, col];
                        finalNums[1, 0] = nums[row + 1, col];
                        finalNums[0, 1] = nums[row, col + 1];
                        finalNums[1, 1] = nums[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine(finalNums[0,0] + " " + finalNums[0, 1]);
            Console.WriteLine(finalNums[1, 0] + " " + finalNums[1, 1]);
            Console.WriteLine(maxSum);

        }
    }
}
