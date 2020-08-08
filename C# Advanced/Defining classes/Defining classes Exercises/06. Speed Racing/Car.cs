using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Speed_Racing
{
    public class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelleDistance;

        public string Model
        {
            get => model;
            set => model = value;
        }
        public double FuelAmount
        {
            get => fuelAmount;
            set => fuelAmount = value;
        }
        public double FuelConsumptionPerKilometer
        {
            get => fuelConsumptionPerKilometer;
            set => fuelConsumptionPerKilometer = value;
        }
        public double TravelleDistance
        {
            get => travelleDistance;
            set => travelleDistance = value;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.travelleDistance = 0;
        }

        public void Drive(int amountOfKm)
        {
            double neededFuel = amountOfKm * fuelConsumptionPerKilometer;
            if (fuelAmount - neededFuel >= 0)
            {
                fuelAmount -= neededFuel;
                travelleDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            Console.WriteLine($"{this.model} {this.fuelAmount:F2} {this.travelleDistance}");
            return "";
        }

    }
}
