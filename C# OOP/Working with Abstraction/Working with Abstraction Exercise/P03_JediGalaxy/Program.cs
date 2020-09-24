using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilX = evilCoordinates[0];
                int evilY = evilCoordinates[1];

                while (evilX >= 0 && evilY >= 0)
                {
                    if (IsInside(evilX, evilY, matrix))
                    {
                        matrix[evilX, evilY] = 0;
                    }
                    evilX--;
                    evilY--;
                }

                int playerX = playerCoordinates[0];
                int playerY = playerCoordinates[1];

                while (playerX >= 0 && playerY < matrix.GetLength(1))
                {
                    if (IsInside(playerX, playerY, matrix))
                    {
                        sum += matrix[playerX, playerY];
                    }

                    playerY++;
                    playerX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static bool IsInside(int x, int y, int[,] matrix)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }
    }
}
