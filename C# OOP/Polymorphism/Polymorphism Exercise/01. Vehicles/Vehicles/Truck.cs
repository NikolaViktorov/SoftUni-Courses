using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public override double FuelQuantity
        {
            get => FuelQuantity;
            set
            {
                if (value >= TankCapacity)
                {
                    FuelQuantity = 0;
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                }
            }
        }
        public override double FuelConsumptionInLitersPerKm { get; set; }
        public override double TankCapacity { get; set; }

        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
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
            // 95% of fuel
            fuel = fuel * 95 / 100;
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
