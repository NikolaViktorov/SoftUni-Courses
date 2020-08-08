using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            char[,] symbols = new char[rows, cols];

            char[] symbolsOnRow = new char[cols];

            for (int row = 0; row < rows; row++)
            {
                symbolsOnRow = Console.ReadLine()
                    .ToCharArray();                                   

                for (int col = 0; col < cols; col++)
                {
                    symbols[row, col] = symbolsOnRow[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (symbols[row, col] == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolToFind} does not occur in the matrix");
        }
    }
}
