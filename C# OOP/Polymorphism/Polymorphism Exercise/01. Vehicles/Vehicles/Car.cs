using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Car : Vehicle
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

        public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
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
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:F2}";
        }
    }
}
