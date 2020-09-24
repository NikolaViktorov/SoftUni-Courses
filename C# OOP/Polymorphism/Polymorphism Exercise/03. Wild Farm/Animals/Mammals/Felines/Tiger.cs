using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        public override string Breed { get; set; }
        public override string LivingRegion { get; set; }
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public Tiger(string breed, string livingRegion, string name, double weight)
        {
            this.Breed = breed;
            this.LivingRegion = livingRegion;
            this.Name = name;
            this.Weight = weight;
        }
        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
