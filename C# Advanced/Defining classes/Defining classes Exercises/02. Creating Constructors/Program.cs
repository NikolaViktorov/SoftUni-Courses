﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);
            Person person1 = new Person(age);
            Person person2 = new Person();

            person.Name = "Stamat";
            person.Age = 20;
            person.Name = "Gosho";
            person.Age = 15;
        }
    }
}
