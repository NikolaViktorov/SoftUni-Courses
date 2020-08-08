using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            string[] input = Console.ReadLine()
                .Split();

            while (input[0] != "Party!")
            {
                string command = input[0];
                string criteria = input[1];
                int lenght = 0;
                string searched = "";

                if (command == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            searched = input[2];
                            people = people
                                .Where(p => !StartsWithFilter(p, searched))
                                .ToList();
                            break;
                        case "EndsWith":
                            searched = input[2];
                            people = people
                                .Where(p => !EndsWithFilter(p, searched))
                                .ToList();
                            break;
                        case "Length":
                            lenght = int.Parse(input[2]);
                            people = people
                                .Where(p => !LengthFilter(p, lenght))
                                .ToList();
                            break;
                    }
                }
                else
                {
                    List<string> peopleToDouble = new List<string>();
                    switch (criteria)
                    {
                        case "StartsWith":
                            searched = input[2];
                            peopleToDouble = people
                                .Where(p => StartsWithFilter(p, searched))
                                .ToList();
                            break;
                        case "EndsWith":
                            searched = input[2];
                            peopleToDouble = people
                                .Where(p => EndsWithFilter(p, searched))
                                .ToList();
                            break;
                        case "Length":
                            lenght = int.Parse(input[2]);
                            peopleToDouble = people
                                .Where(p => LengthFilter(p, lenght))
                                .ToList();
                            break;
                    }
                    peopleToDouble.ForEach(p => people.Add(p));
                }                
                input = Console.ReadLine()
                .Split();
            }

            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static Func<string, int, bool> LengthFilter = (name, length)
            => name.Length == length;
        static Func<string, string, bool> StartsWithFilter = (name, param)
            => name.StartsWith(param);
        static Func<string, string, bool> EndsWithFilter = (name, param)
            => name.EndsWith(param);
        static Func<string, string, bool> ContainsFilter = (name, param)
            => name.Contains(param);
    }
}
