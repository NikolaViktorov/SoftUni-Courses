using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ");

                string name = input[0];
                int age = int.Parse(input[1]);

                if (people.ContainsKey(name) == false)
                {
                    people.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int ageCriteria = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split();

            people = people
                .Where(p => condition == "younger" ? p.Value < ageCriteria : p.Value >= ageCriteria)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var person in people)
            {
                Printer(person, format);
            }
           
        }

        static void Printer(KeyValuePair<string, int> person, string[] pattern)
        {
            if (pattern.Length == 1)
            {
                Console.WriteLine(pattern[0] == "name" ? $"{person.Key}" :
                    $"{person.Value}");
            }
            else
            {
                Console.WriteLine($"{person.Key} - {person.Value}");
            }
        }

    }
}