using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;


            int[,] numbers = new int[rows, cols];

            int[] numbersOnRow = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    numbers[row, col] = numbersOnRow[col];
                }
            }

            int firstDiagSum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == col)
                    {
                        firstDiagSum += numbers[row, col];
                    }
                }
            }

            int secondDiagSum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + col == numbers.GetLength(0) - 1)
                    {
                        secondDiagSum += numbers[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagSum - secondDiagSum)); 
        }
    }
}
