using System.Linq;
using System;
using System.Collections.Generic;

namespace _06._Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car currCar = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(currCar);
            }

            string[] input = Console.ReadLine()
                .Split();

            while (input[0] != "End")
            {
                string command = input[0];
                string model = input[1];
                int amountOfKm = int.Parse(input[2]);

                cars.Where(x => x.Model == model).FirstOrDefault().Drive(amountOfKm);

                input = Console.ReadLine()
               .Split();
            }
            cars.ForEach(c => c.ToString());

        }
    }
}
