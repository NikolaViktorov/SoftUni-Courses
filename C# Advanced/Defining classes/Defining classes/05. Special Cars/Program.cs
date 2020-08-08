using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        int horsePower;
        double cubicCapacity;

        public int HorsePower
        {
            get => horsePower;
            set => horsePower = value;
        }
        public double CubicCapacity
        {
            get => cubicCapacity;
            set => cubicCapacity = value;
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.horsePower = horsePower;
            this.cubicCapacity = cubicCapacity;
        }
    }
    public class Car
    {
        int year;
        string make;
        string model;
        double fuelQuantity;
        double fuelConsumption;

        public Engine Engine;
        public Tire[] Tires = new Tire[4];


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

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
             : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
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
            builder.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            builder.Append($"FuelQuantity: {this.fuelQuantity}");
            return builder.ToString();
        }
    }
    public class Tire
    {
        int year;
        double pressure;

        public int Year
        {
            get => year;
            set => year = value;
        }
        public double Pressure
        {
            get => pressure;
            set => pressure = value;
        }

        public Tire(int year, double pressure)
        {
            this.year = year;
            this.pressure = pressure;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            // reading tires
            string[] inputTir = Console.ReadLine()
                .Split();

            while (inputTir[0] != "No")
            {
                Tire firstTire = new Tire(int.Parse(inputTir[0]), double.Parse(inputTir[1]));
                Tire secondTire = new Tire(int.Parse(inputTir[2]), double.Parse(inputTir[3]));
                Tire thirdTire = new Tire(int.Parse(inputTir[4]), double.Parse(inputTir[5]));
                Tire fourthTire = new Tire(int.Parse(inputTir[6]), double.Parse(inputTir[7]));

                tires.Add(firstTire);
                tires.Add(secondTire);
                tires.Add(thirdTire);
                tires.Add(fourthTire);

                inputTir = Console.ReadLine()
                .Split();
            }

            // reading engines
            string[] inputEng = Console.ReadLine()
                .Split();

            while (inputEng[0] != "Engines")
            {
                Engine engine = new Engine(int.Parse(inputEng[0]), double.Parse(inputEng[1]));

                engines.Add(engine);

                inputEng = Console.ReadLine()
                .Split();
            }

            // reading cars
            string[] inputCar = Console.ReadLine()
                .Split();

            while (inputCar[0] != "Show")
            {
                int engIndex = int.Parse(inputCar[5]);
                int tireIndex = int.Parse(inputCar[6]);
                Tire[] currTires = new Tire[4]
                {
                    tires[tireIndex],
                    tires[tireIndex + 1],
                    tires[tireIndex + 2],
                    tires[tireIndex + 3]
                };

                Car car = new Car(inputCar[0], inputCar[1],int.Parse(inputCar[2]), double.Parse(inputCar[3]), 
                    double.Parse(inputCar[4]), engines[engIndex], currTires);

                cars.Add(car);

                inputCar = Console.ReadLine()
                .Split();
            }

            // Printing output
            foreach (Car car in cars)
            {
                double tirePressureSum = 0;
                foreach (Tire tire in car.Tires)
                {
                    tirePressureSum += tire.Pressure;
                }
                if (car.Year >= 2017 && car.Engine.HorsePower >= 330 
                    && tirePressureSum >= 9 && tirePressureSum <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
