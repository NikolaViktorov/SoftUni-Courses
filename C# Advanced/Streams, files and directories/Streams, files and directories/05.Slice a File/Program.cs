using System;
using System.IO;

namespace _05.Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string inputName = "input.txt";
            string inputPath = Path.Combine(path, inputName);

            using (var inputFile = new FileStream(inputPath, FileMode.Open))
            {
                long size = inputFile.Length;
                long partSize = (long)Math.Ceiling((double)size / 4);

                byte[] buffer = new byte[partSize];

                for (int i = 0; i < 4; i++)
                {
                    using (var outputyFile = new FileStream($"files\\Part-{i + 1}.txt", FileMode.Create))
                    {
                        int readBytes = inputFile.Read(buffer, 0, buffer.Length);
                        outputyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
