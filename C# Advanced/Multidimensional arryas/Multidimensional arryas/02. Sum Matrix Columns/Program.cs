using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            int[,] numbers = new int[rows, columns];

            int[] numbersOnRow = new int[columns];

            for (int row = 0; row < rows; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    numbers[row, col] = numbersOnRow[col];
                }
            }

            int[] colSum = new int[columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    colSum[col] += numbers[row, col];
                }
            }

            foreach (int num in colSum)
            {
                Console.WriteLine(num);
            }

        }
    }
}
