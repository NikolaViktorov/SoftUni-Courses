using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();

            string[] tokens = Console.ReadLine()
                .Split();
            while (tokens[0] != "End")
            {
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);
                    citizens.Add(citizen);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                tokens = Console.ReadLine()
                .Split();
            }
            string fakeDigits = Console.ReadLine();
            citizens.ForEach(c => c.CheckId(fakeDigits));
            robots.ForEach(r => r.CheckId(fakeDigits));
        }
    }
}
