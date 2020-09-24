using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Animals.Birds
{
    public class Owl : Bird
    {
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public override double WingSize { get; set; }

        public Owl(double wingSize, string name, double weight)
        {
            this.WingSize = wingSize;
            this.Name = name;
            this.Weight = weight;
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
