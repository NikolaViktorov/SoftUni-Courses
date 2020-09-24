using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();
                if (tokens.Length == 4)
                {
                    string Citizenname = tokens[0];
                    string id = tokens[2];
                    int age = int.Parse(tokens[1]);
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(Citizenname, age, id, birthdate);
                    citizens.Add(citizen);
                }
                else
                {
                    string RebelName = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(RebelName, age, group);
                    rebels.Add(rebel);
                }
            }

            string name = Console.ReadLine();
            while (name != "End")
            {
                if (citizens.Count > 0)
                {
                    foreach (var citizen in citizens)
                    {
                        if (citizen.Name == name)
                        {
                            citizen.BuyFood();
                        }
                    }
                }
                if (rebels.Count > 0)
                {
                    foreach (var rebel in rebels)
                    {
                        if (rebel.Name == name)
                        {
                            rebel.BuyFood();
                        }
                    }
                }
                name = Console.ReadLine();
            }

            Console.WriteLine(citizens.Sum(c => c.Food) + rebels.Sum(r => r.Food));
            
        }
    }
}
