using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var chest = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long rocks = 0;
            long money = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "")
                {
                    continue;
                }
                else if (input < chest.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (item)
                {
                    case "Gem":
                        if (!chest.ContainsKey(item))
                        {
                            if (chest.ContainsKey("Gold"))
                            {
                                if (amount > chest["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (chest[item].Values.Sum() + amount > chest["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!chest.ContainsKey(item))
                        {
                            if (chest.ContainsKey("Gem"))
                            {
                                if (amount > chest["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (chest[item].Values.Sum() + amount > chest["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!chest.ContainsKey(item))
                {
                    chest[item] = new Dictionary<string, long>();
                }

                if (!chest[item].ContainsKey(name))
                {
                    chest[item][name] = 0;
                }

                chest[item][name] += amount;
                if (item == "Gold")
                {
                    gold += amount;
                }
                else if (item == "Gem")
                {
                    rocks += amount;
                }
                else if (item == "Cash")
                {
                    money += amount;
                }
            }

            foreach (var item in chest)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}