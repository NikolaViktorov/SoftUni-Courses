using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                Engine engine = new Engine(int.Parse(parameters[2]), int.Parse(parameters[1]));
                Cargo cargo = new Cargo(int.Parse(parameters[3]), parameters[4]);
                Tire tire1 = new Tire( int.Parse(parameters[6]), double.Parse(parameters[5]));
                Tire tire2 = new Tire( int.Parse(parameters[8]), double.Parse(parameters[7]));
                Tire tire3 = new Tire( int.Parse(parameters[10]), double.Parse(parameters[9]));
                Tire tire4 = new Tire( int.Parse(parameters[12]), double.Parse(parameters[11]));
                cars.Add(new Car(model, engine, cargo, tire1, tire2, tire3, tire4));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargo.Type == "fragile" && x.tires.Any(y => y.Pressure < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargo.Type == "flamable" && x.engine.Power > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
