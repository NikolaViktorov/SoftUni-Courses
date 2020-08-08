using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();

            string input = Console.ReadLine();

            while (input?.ToLower() != "party")
            {
                if (char.IsDigit(input[0]) == true)
                {
                    vips.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input?.ToLower() != "end")
            {
                if (char.IsDigit(input[0]) == true)
                {
                    vips.Remove(input);
                }
                else
                {
                    guests.Remove(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(vips.Count + guests.Count);

            foreach (string vip in vips)
            {
                Console.WriteLine(vip);
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }                    
        }
    }
}
