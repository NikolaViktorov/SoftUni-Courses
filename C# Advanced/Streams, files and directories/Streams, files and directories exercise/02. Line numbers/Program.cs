using System;
using System.IO;
using System.Linq;

namespace _02._Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string outputPath = "output.txt";

            string[] lines = File.ReadAllLines(textPath);
            int counter = 1;
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (string line in lines)
                {
                    int lettterCount = line.Count(x => char.IsLetter(x));
                    int symbolCount = line.Count(x => char.IsPunctuation(x));

                    writer.WriteLine($"Line {counter}: {line} ({lettterCount})({symbolCount})");

                    counter++;
                }

            }

        }
    }
}
