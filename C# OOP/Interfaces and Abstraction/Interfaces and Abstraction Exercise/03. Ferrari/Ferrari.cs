using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public string Model { get; set; }
        public string Driver { get; set; }

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string PushGasPedal()
        {
            return "Brakes!";
        }

        public string UseBrakes()
        {
            return "Gas!";
        }
        public override string ToString()
        {
            return $"{Model}/{UseBrakes()}/{PushGasPedal()}/{Driver}";
        }
    }
}
