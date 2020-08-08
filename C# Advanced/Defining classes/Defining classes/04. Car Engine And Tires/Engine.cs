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
}
