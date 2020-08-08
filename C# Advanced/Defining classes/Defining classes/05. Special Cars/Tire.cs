using System;
using System.Collections.Generic;
using System.Text;

namespace CaraManufacturer
{
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
}
