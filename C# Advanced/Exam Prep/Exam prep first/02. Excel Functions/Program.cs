using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] table = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] tableRowInfo = Console.ReadLine()
                    .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                table[row] = new string[tableRowInfo.Length];
                for (int col = 0; col < tableRowInfo.Length; col++)
                {
                    table[row][col] = tableRowInfo[col];
                }
            }

            string[] tokens = Console.ReadLine()
                .Split();

            string command = tokens[0];
            string header = tokens[1];

            int headerIndex = Array.IndexOf(table[0], header);

            if (command == "sort")
            {
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(headerIndex);
                    Console.WriteLine(string.Join(" | ", lineToPrint));

                    table[row] = lineToPrint.ToArray();
                }

            }
            else if (command == "filter")
            {
                string parameter = tokens[2];
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
            
        }
    }
}
