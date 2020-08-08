using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[,] warriors = new int[numOfWaves, 3];

            int currIndex = 0;
            int addedPlates = 0;
            bool goOrNot = false;

            for (int i = 0; i < numOfWaves; i++)
            {
                int[] currWaveInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 3 == 0 && i != 0)
                {
                    plates.AddRange(currWaveInfo);
                    addedPlates++;
                    numOfWaves++;
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (currWaveInfo.Length == 3)
                        {
                            warriors[i - addedPlates, j] = currWaveInfo[j];
                        }
                        else if (currWaveInfo.Length == 2 && j < 2)
                        {
                            warriors[i - addedPlates, j] = currWaveInfo[j];
                        }
                        else if (currWaveInfo.Length == 1 && j < 1)
                        {
                            warriors[i - addedPlates, j] = currWaveInfo[j];
                        }
                    }

                    for (int j = 2; j >= 0; j--)
                    {
                        int temp = warriors[i - addedPlates, j];
                        warriors[i - addedPlates, j] -= plates[0];
                        plates[0] -= temp;

                        if (plates[0] <= 0)
                        {
                            plates.RemoveAt(0);
                        }
                        if (warriors[i - addedPlates, j] > 0)
                        {
                            j++;
                        }
                        if (plates.Count == 0)
                        {
                            if ((i + 1) % 3 == 0)
                            {
                                break;
                            }
                            else
                            {
                                goOrNot = true;
                                break;
                            }
                        }
                    }
                }
                currIndex = i;
                if (goOrNot == true)
                {
                    break;
                }
            }
            if ((currIndex + 1 - addedPlates) % 3 == 0)
            {
                int[] lastPlateInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                plates.AddRange(lastPlateInfo);
            }

            Stack<int> warLeft = new Stack<int>();

            if (plates.Count == 0)
            {
                for (int i = 0; i < warriors.GetLength(0); i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (warriors[i, j] > 0)
                        {
                            warLeft.Push(warriors[i, j]);
                        }
                    }
                }

                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warLeft)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
