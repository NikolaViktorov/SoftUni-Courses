using System;
using System.IO;

namespace _02.Line_Numbers
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
                int count = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(outputPath))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            Console.WriteLine(line);
                            writer.WriteLine(line);
                        }

                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
