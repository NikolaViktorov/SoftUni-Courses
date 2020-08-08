using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            string outputName = "output.txt";
            string outputPath = Path.Combine(path, outputName);

            using (var reader = new StreamReader(filePath))
            {
                int count = 1;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(outputPath))
                {
                    while (line != null)
                    {
                        line = $"{count++}. {line}";
                        Console.WriteLine(line);
                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
