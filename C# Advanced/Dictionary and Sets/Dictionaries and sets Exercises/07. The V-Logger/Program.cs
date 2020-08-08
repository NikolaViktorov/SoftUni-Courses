using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // followed - 3 words
            // joined - 4 words

            List<Vlogger> vloggers = new List<Vlogger>();
            List<string> vloggersNames = new List<string>();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Statistics")
            {
                if (input.Length == 4)
                {
                    string name = input[0];
                    bool exist = false;
                    Vlogger vlogger = new Vlogger(name);
                    foreach (var curVlogger in vloggers)
                    {
                        if (curVlogger.Name == vlogger.Name)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (exist == false)
                    {
                        vloggers.Add(vlogger);
                        vloggersNames.Add(vlogger.Name);
                    }
                }
                else if (input.Length == 3)
                {
                    string followingVlogger = input[0];
                    string followedVlogger = input[2];
                    if (vloggersNames.Contains(followedVlogger)
                        && vloggersNames.Contains(followingVlogger))
                    {
                        foreach (var vlogger in vloggers)
                        {
                            if (vlogger.followers.Contains(followingVlogger) == false
                                && vlogger.Name != followingVlogger
                                && vlogger.Name == followedVlogger)
                            {
                                vlogger.followers.Add(followingVlogger);
                            }
                            if (vlogger.following.Contains(followedVlogger) == false
                                && vlogger.Name != followedVlogger
                                && vlogger.Name == followingVlogger)
                            {
                                vlogger.following.Add(followedVlogger);
                            }
                        }
                    }
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Vlogger mostFamous = new Vlogger(" ");

            foreach (var vlogger in vloggers)
            {
                if (vlogger.followers.Count > mostFamous.followers.Count)
                {
                    vlogger.followers.OrderBy(x => x);
                    mostFamous = vlogger;
                }
            }

            vloggers.Remove(mostFamous);
            mostFamous.followers.OrderByDescending(x => x);

            Console.WriteLine($"1. {mostFamous.Name} : {mostFamous.followers.Count} followers," +
                $" {mostFamous.following.Count} following");

            foreach (var follower in mostFamous.followers)
            {
                Console.WriteLine($"*  {follower}");
            }

            vloggers.OrderByDescending(x => x.followers.Count);

            for (int i = 0; i < vloggers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vloggers[i].Name} : {vloggers[i].followers.Count} followers," +
                    $" {vloggers[i].following.Count} following");
            }
        }
    }
}
