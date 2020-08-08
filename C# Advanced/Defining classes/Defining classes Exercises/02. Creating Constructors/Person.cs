using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        string name;
        int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person() : this("No name", 1) { }
        public Person(int age) : this("No name", age) { }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
