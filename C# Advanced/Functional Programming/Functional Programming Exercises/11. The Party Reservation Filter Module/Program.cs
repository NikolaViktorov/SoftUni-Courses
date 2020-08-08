using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            List<string> filters = new List<string>();

            string[] input = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Print")
            {
                string action = input[0];

                if (action == "Add filter")
                {
                    filters.Add($"{input[1]};{input[2]}");
                }
                else if (action == "Remove filter")
                {
                    filters.Remove($"{input[1]};{input[2]}");
                }

                input = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string filter in filters)
            {
                string[] filterInfo = filter.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string criteria = filterInfo[0];
                string param = filterInfo[1];

                switch (criteria)
                {
                    case "Starts with":
                        people = people
                            .Where(p => !StartsWithFilter(p, param))
                            .ToList();
                        break;
                    case "Ends with":
                        people = people
                            .Where(p => !EndsWithFilter(p, param))
                            .ToList();
                        break;
                    case "Length":
                        people = people
                            .Where(p => !LengthFilter(p, int.Parse(param)))
                            .ToList();
                        break;
                    case "Contains":
                        people = people
                            .Where(p => !ContainsFilter(p, param))
                            .ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", people));
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
