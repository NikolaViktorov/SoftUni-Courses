using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public override string LivingRegion { get; set; }
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public Mouse(string livingRegion, string name, double weight)
        {
            this.LivingRegion = livingRegion;
            this.Name = name;
            this.Weight = weight;
        }

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
