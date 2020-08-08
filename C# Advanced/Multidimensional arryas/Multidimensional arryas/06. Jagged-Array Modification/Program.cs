using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[][] nums = new int[rows][];

            int[] numbersOnRow = new int[cols];

            for (int row = 0; row < nums.Length; row++)
            {
                numbersOnRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                nums[row] = new int[numbersOnRow.Length];

                for (int col = 0; col < nums[row].Length; col++)
                {
                    nums[row][col] = numbersOnRow[col];
                }
            }

            string[] input = Console.ReadLine()
                .Split();   

            while (input[0] != "END")
            {
                string command = input[0];

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int num = int.Parse(input[3]);

                if (row < 0 || row >= nums.Length || col < 0 || col >= nums[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine()
                .Split();
                    continue;
                }
                switch (command)
                {
                    case "Add":
                        nums[row][col] += num;
                        break;
                    case "Subtract":
                        nums[row][col] -= num;
                        break;
                }

                input = Console.ReadLine()
                .Split();
            }

            for (int row = 0; row < nums.Length; row++)
            {
                for (int col = 0; col < nums[row].Length; col++)
                {
                    Console.Write(nums[row][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
