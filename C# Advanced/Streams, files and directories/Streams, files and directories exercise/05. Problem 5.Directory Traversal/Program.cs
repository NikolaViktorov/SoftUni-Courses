using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Problem_5.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> filesInfo =
                new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo dirInfo = new DirectoryInfo(".");
            FileInfo[] allFiles = dirInfo.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                double size = file.Length / 1024d;
                string name = file.Name;
                string extension =file.Extension;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }
                if (!filesInfo[extension].ContainsKey(name))
                {
                    filesInfo[extension].Add(name, size);
                }
            }

            var sorted = filesInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string reportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";
            
            foreach (var (extension, value) in sorted)
            {
                File.AppendAllText(reportPath, extension + Environment.NewLine);
                foreach (var (name, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(reportPath, $"--{name} - {Math.Round(size, 3)}kb"
                        + Environment.NewLine);
                }
            }


        }
    }
}
