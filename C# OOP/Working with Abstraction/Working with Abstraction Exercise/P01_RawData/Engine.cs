using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        public int Power { get; set; }
        public int Speed { get; set; }

        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }
    }
}
