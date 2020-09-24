using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new Tire[] { tire1, tire2, tire3, tire4 };
        }
    }
}
