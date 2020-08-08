using System;

namespace _02._Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int parisEng = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            int pCol = 0;
            int pRow = 0;

            bool gotPrincess = false;
            bool died = false;

            char[][] field = new char[rows][];

            for (int row = 0; row < field.Length; row++)
            {
                string currentRow = Console.ReadLine();
                int length = currentRow.Length;
                field[row] = new char[length];
                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        pRow = row;
                        pCol = col;
                    }
                }
            }

            while (parisEng > 0)
            {
                if (gotPrincess)
                {
                    break;
                }

                string[] tokens = Console.ReadLine()
                    .Split();

                string command = tokens[0];
                int rowToSpawn = int.Parse(tokens[1]);
                int colToSpawn = int.Parse(tokens[2]);

                field[rowToSpawn][colToSpawn] = 'S';

                switch (command)
                {
                    case "up":
                        parisEng--;
                        if (pRow - 1 >= 0)
                        {
                            field[pRow][pCol] = '-';
                            pRow--;
                            if (field[pRow][pCol] == 'H')
                            {
                                field[pRow][pCol] = '-';
                                gotPrincess = true;
                                break;
                            }
                            else if (field[pRow][pCol] == 'S')
                            {
                                parisEng -= 2;
                            }
                            field[pRow][pCol] = 'P';
                        }
                        break;
                    case "down":
                        parisEng--;
                        if (pRow + 1 < rows)
                        {
                            field[pRow][pCol] = '-';
                            pRow++;
                            if (field[pRow][pCol] == 'H')
                            {
                                field[pRow][pCol] = '-';
                                gotPrincess = true;
                                break;
                            }
                            else if (field[pRow][pCol] == 'S')
                            {
                                parisEng -= 2;
                            }
                            field[pRow][pCol] = 'P';
                        }
                        break;
                    case "left":
                        parisEng--;
                        if (pCol - 1 >= 0)
                        {
                            field[pRow][pCol] = '-';
                            pCol--;
                            if (field[pRow][pCol] == 'H')
                            {
                                field[pRow][pCol] = '-';
                                gotPrincess = true;
                                break;
                            }
                            else if (field[pRow][pCol] == 'S')
                            {
                                parisEng -= 2;
                            }
                            field[pRow][pCol] = 'P';
                        }
                        break;
                    case "right":
                        parisEng--;
                        if (pCol + 1 < rows)
                        {
                            field[pRow][pCol] = '-';
                            pCol++;
                            if (field[pRow][pCol] == 'H')
                            {
                                field[pRow][pCol] = '-';
                                gotPrincess = true;
                                break;
                            }
                            else if (field[pRow][pCol] == 'S')
                            {
                                parisEng -= 2;
                            }
                            field[pRow][pCol] = 'P';
                        }
                        break;
                }
            }

            died = parisEng <= 0;

            if (gotPrincess)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEng}");
            }
            else
            {
                Console.WriteLine($"Paris died at {pRow};{pCol}.");
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'P' && died)
                    {
                        field[i][j] = 'X';
                    }
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
