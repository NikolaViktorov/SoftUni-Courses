using System;
using System.IO;
using System.Linq;

namespace _01._Even_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = @"text.txt";

            using (StreamReader reader = new StreamReader(textPath))
            {
                int counter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedLine = ReverseWords(replacedSymbols);

                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(reversedLine);
                    }

                    line = reader.ReadLine();
                    counter++;
                }
            }
        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSymbols(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@"); 
        }
    }
}
