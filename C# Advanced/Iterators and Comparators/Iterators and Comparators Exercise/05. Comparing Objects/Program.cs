using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            List<Person> people = new List<Person>();

            while (input[0] != "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[1];
                Person currPerson = new Person(name, age, town);

                people.Add(currPerson);

                input = Console.ReadLine()
                .Split(' ');
            }

            int indexToSearch = int.Parse(Console.ReadLine()) - 1;
            Person searched = people[indexToSearch];

            int countOfMatches = 0;
            int numberOfNotEqualPeople = people.Count;

            for (int i = 0; i < people.Count; i++)
            {
                if (i == indexToSearch == false)
                {
                    if (searched.CompareTo(people[i]) == 0)
                    {
                        countOfMatches++;
                        numberOfNotEqualPeople--;
                    }
                }
            }

            if (countOfMatches != 0)
            {
                Console.WriteLine($"{countOfMatches} {numberOfNotEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
