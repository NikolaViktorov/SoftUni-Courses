using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        public override double FuelQuantity { get; set; }
        public override double FuelConsumptionInLitersPerKm { get; set; }
        public override double TankCapacity { get; set; }

        public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        {
            if (fuelQuantity >= tankCapacity)
            {
                this.FuelQuantity = 0;
                Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
            this.TankCapacity = tankCapacity;
        }
        public override void Drive(double distance)
        {
            if (FuelQuantity - (FuelConsumptionInLitersPerKm + 0.9) * distance >= 0)
            {
                FuelQuantity -= (FuelConsumptionInLitersPerKm + 0.9) * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public override void Refill(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (fuel >= TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuel;
            }
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:F2}";
        }
    }
}
