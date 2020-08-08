using System;
using System.Linq;

namespace _04._Matrix_Shuffling
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

            string[][] nums = new string[rows][];
            string[] numbersOnRow = new string[cols];

            for (int row = 0; row < rows; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                nums[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    nums[row][col] = numbersOnRow[col];
                }
            }

            string[] input2 = Console.ReadLine()
                .Split();

            while (input2[0] != "END")
            {
                if (input2[0] == "swap")
                {
                    int row1 = 0;
                    int row2 = 0;
                    int col1 = 0;
                    int col2 = 0;
                    try
                    {
                        row1 = int.Parse(input2[1]);
                        col1 = int.Parse(input2[2]);
                        row2 = int.Parse(input2[3]);
                        col2 = int.Parse(input2[4]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Invalid input!");
                        input2 = Console.ReadLine()
                        .Split();
                        continue;
                        throw;
                    }
                    

                    if (row1 < 0 || row1 >= rows || col1 < 0 || col1 >= cols
                        || row2 < 0 || row2 >= rows || col2 < 0 || col2 >= cols)
                    {
                        Console.WriteLine($"Invalid input!");
                        input2 = Console.ReadLine()
                        .Split();
                        continue;
                    }

                    string temp = nums[row1][col1];
                    nums[row1][col1] = nums[row2][col2];
                    nums[row2][col2] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(nums[row][col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input2 = Console.ReadLine()
                .Split();
            }
        }
    }
}
