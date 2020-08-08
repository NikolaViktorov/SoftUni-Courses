using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_count
{
    class Program
    {
        static void Main(string[] args)
        {
            // case sens -CAPITAL LETTER SHOULD BE NOTICED
            string textPath = "text.txt";
            string wordsPath = "words.txt";
            string expectedResultPath = "expectedResult.txt";
            string outputPath = "actualResult.txt";

            string[] words = File.ReadAllLines(wordsPath);
            SortedDictionary<string, int> wordsOcc = new SortedDictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsOcc.ContainsKey(word.ToLower()) == false)
                {
                    wordsOcc.Add(word.ToLower(), 0);
                }
            }

            string[] lines = File.ReadAllLines(textPath);

            foreach (string line in lines)
            {
                string[] currLine = line
                    .ToLower()
                    .Split(new char[] { ' ', '.', '-', '!', ',' });

                foreach (var word in currLine)
                {
                    if (wordsOcc.ContainsKey(word))
                    {
                        wordsOcc[word]++;
                    }
                }
            }

            var items = from pair in wordsOcc
                        orderby pair.Value descending
                        select pair;

            using (StreamWriter writer = new StreamWriter(expectedResultPath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var item in wordsOcc)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
