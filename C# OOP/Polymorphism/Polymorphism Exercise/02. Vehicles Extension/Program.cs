using _01._Vehicles.Vehicles;
using _02._Vehicles_Extension.Vehicles;
using System;

namespace _01._Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),
                double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine()
                .Split();
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine()
                .Split();
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]),
                double.Parse(busInfo[3]));

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
                    else if (tokens[1] == "Bus")
                    {
                        bus.Drive(kmToTravel);
                    }
                }
                else if (tokens[0] == "DriveEmtpy")
                {
                    double kmToTravel = double.Parse(tokens[2]);
                    bus.DriveEmpty(kmToTravel);
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
                    else if (tokens[1] == "Bus")
                    {
                        bus.Drive(fuel);
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
