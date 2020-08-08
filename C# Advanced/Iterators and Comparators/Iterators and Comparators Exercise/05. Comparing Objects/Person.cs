using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public string Town { get; set; }
        public int Age { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.Name .Equals(other.Name))
            {
                return 0;
            }
            if (this.Age == other.Age)
            {
                return 0;
            }
            if (this.Town.Equals(other.Town))
            {
                return 0;
            }
            return -1;
        }
    }
}
