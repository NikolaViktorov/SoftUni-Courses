using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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
            return -1;
        }

    }
}
