using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split();

                string currName = personInfo[0];
                int currAge = int.Parse(personInfo[1]);

                Person person = new Person(currName, currAge);

                people.Add(person);
            }

            people = people.Where(p => p.Age > 30).ToList();
            people = people.OrderBy(p => p.Name).ToList();

            people.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
