using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        int year;
        string make;
        string model;
        double fuelQuantity;
        double fuelConsumption;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) 
        : this(make, model, year)
        {
            this.fuelConsumption = fuelConsumption;
            this.fuelQuantity = fuelQuantity;    
        }
        public Car(string make, string model, int year)
        : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }
        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }

        public string Make
        {
            get => make;
            set => make = value;
        }
        public string Model
        {
            get => model;
            set => model = value;
        }
        public int Year
        {
            get => year;
            set => year = value;
        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public void Drive(double distance)
        {
            if (this.fuelQuantity - (distance * this.fuelConsumption / 100) >= 0)
            {
                this.fuelQuantity -= (distance * this.fuelConsumption / 100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Make: {this.make}");
            builder.AppendLine($"Model: {this.model}");
            builder.AppendLine($"Year: {this.year}");
            builder.Append($"Fuel: {this.fuelQuantity:F2}L");
            return builder.ToString();
        }
    }
}
