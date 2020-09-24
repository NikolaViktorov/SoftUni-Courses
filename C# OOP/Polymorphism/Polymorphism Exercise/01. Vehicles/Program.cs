using _01._Vehicles.Vehicles;
using System;

namespace _01._Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = Console.ReadLine()
                .Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();
                if (tokens[0] == "Drive")
                {
                    double kmToTravel = double.Parse(tokens[2]);
                    if (tokens[1] == "Car")
                    {
                        car.Drive(kmToTravel);
                    }
                    else if (tokens[1] == "Truck")
                    {
                        truck.Drive(kmToTravel);
                    }
                }
                else if (tokens[0] == "Refuel")
                {
                    double fuel= double.Parse(tokens[2]);
                    if (tokens[1] == "Car")
                    {
                        car.Refill(fuel);
                    }
                    else if (tokens[1] == "Truck")
                    {
                        truck.Refill(fuel);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
