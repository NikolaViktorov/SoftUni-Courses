using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public override double FuelQuantity { get; set; }
        public override double FuelConsumptionInLitersPerKm { get; set; }
        public override double TankCapacity { get; set; }

        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
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
            if (FuelQuantity - (FuelConsumptionInLitersPerKm + 1.6) * distance >= 0)
            {
                FuelQuantity -= (FuelConsumptionInLitersPerKm + 1.6) * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
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
                fuel = fuel * 95 / 100;
                FuelQuantity += fuel;
            }
            
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
