using System;
using System.Collections.Generic;

namespace _06._Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();
            List<Pet> pets = new List<Pet>();

            string[] tokens = Console.ReadLine()
                .Split();
            while (tokens[0] != "End")
            {
                switch (tokens[0])
                {
                    case "Pet":
                        string name = tokens[1];
                        string birthdate = tokens[2];

                        Pet pet = new Pet(name, birthdate);
                        pets.Add(pet);
                        break;
                    case "Robot":
                        string model = tokens[0];
                        string id = tokens[1];

                        Robot robot = new Robot(model, id);
                        robots.Add(robot);
                        break;
                    case "Citizen":
                        string CitizenName = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string CitizenId = tokens[3];
                        string CitizenBirthdate = tokens[4];

                        Citizen citizen = new Citizen(CitizenName, age, CitizenId, CitizenBirthdate);
                        citizens.Add(citizen);
                        break;
                }
                tokens = Console.ReadLine()
                .Split();
            }
            string year = Console.ReadLine();
            pets.ForEach(p => p.CheckBirthdate(year));
            citizens.ForEach(c => c.CheckBirthdate(year));
            
        }
    }
}
