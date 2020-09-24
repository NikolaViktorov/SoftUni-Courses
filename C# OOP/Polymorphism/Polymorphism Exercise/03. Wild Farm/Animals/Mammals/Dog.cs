using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Animals.Mammal
{
    public class Dog : Mammal
    {
        public override string LivingRegion { get; set; }
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }
        public Dog(string livingRegion, string name, double weight)
        {
            this.LivingRegion = livingRegion;
            this.Name = name;
            this.Weight = weight;
        }
        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
