using System;

namespace _1._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int starsCount = 1;
            bool nextSide = false;
            int spaces = n - 1;

            for (int i = 1; i <= n * 2 - 1; i++)
            {
                DrawLine(starsCount, spaces);
                if (starsCount == n)
                {
                    nextSide = true;
                }
                if (nextSide == false)
                {
                    starsCount++;
                    spaces--;
                }
                else
                {
                    starsCount--;
                    spaces++;
                }
                Console.WriteLine();
            }
        }

        static void DrawLine (int n, int spaces)
        {
            for (int j = 0; j < spaces; j++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < n; i++)
            {
                
                Console.Write("* ");
            }
            for (int j = 0; j < spaces; j++)
            {
                Console.Write(" ");
            }
        }
    }
}
