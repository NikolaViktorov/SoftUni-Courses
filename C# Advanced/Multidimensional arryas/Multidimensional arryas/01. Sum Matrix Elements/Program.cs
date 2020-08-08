using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
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
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    numbers[row, col] = numbersOnRow[col];
                }
            }

            Console.WriteLine(numbers.GetLength(0));
            Console.WriteLine(numbers.GetLength(1));
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }

    }
}
