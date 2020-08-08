using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> coloredClothes
                = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (coloredClothes.ContainsKey(color) == false)
                {
                    coloredClothes.Add(color, new Dictionary<string, int>());
                }
                foreach (var cloth in clothes)
                {
                    if (coloredClothes[color].ContainsKey(cloth))
                    {
                        coloredClothes[color][cloth]++;
                    }
                    else
                    {
                        coloredClothes[color].Add(cloth, 1);
                    }
                }      
            }

            string[] needed = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string neededColor = needed[0];
            string neededCloth = needed[1];

            foreach (var coloredCloth in coloredClothes)
            {
                Console.WriteLine($"{coloredCloth.Key} clothes:");
                foreach (var cloth in coloredCloth.Value)
                {
                    if (neededCloth == cloth.Key && neededColor == coloredCloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
