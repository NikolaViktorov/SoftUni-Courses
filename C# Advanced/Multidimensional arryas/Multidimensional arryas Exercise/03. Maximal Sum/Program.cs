using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] nums = new int[rows, cols];

            int[] numbersOnRow = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    nums[row, col] = numbersOnRow[col];
                }
            }

            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[3, 3];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currSum = nums[row, col] + nums[row + 1, col + 1] + nums[row + 1, col] +
                        nums[row, col + 1] + nums[row + 2, col + 1] + nums[row + 2, col + 2] +
                        nums[row + 1, col + 2] + nums[row, col + 2] + nums[row + 2, col];

                    if (maxSum < currSum)
                    {
                        maxMatrix[0, 0] = nums[row, col];
                        maxMatrix[0, 1] = nums[row, col + 1];
                        maxMatrix[0, 2] = nums[row, col + 2];
                        maxMatrix[1, 0] = nums[row + 1, col];
                        maxMatrix[1, 1] = nums[row + 1, col + 1];
                        maxMatrix[1, 2] = nums[row + 1, col + 2];
                        maxMatrix[2, 0] = nums[row + 2, col];
                        maxMatrix[2, 1] = nums[row + 2, col + 1];
                        maxMatrix[2, 2] = nums[row + 2, col + 2];
                        maxSum = currSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{maxMatrix[0, 0]} {maxMatrix[0, 1]} {maxMatrix[0, 2]}");
            Console.WriteLine($"{maxMatrix[1, 0]} {maxMatrix[1, 1]} {maxMatrix[1, 2]}");
            Console.WriteLine($"{maxMatrix[2, 0]} {maxMatrix[2, 1]} {maxMatrix[2, 2]}");

        }
    }
}
