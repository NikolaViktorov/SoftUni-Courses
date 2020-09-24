using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Animals
{
    public abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract double Weight { get; set; }
        public abstract int FoodEaten { get; set; }

        public abstract void AskForFood();
        public abstract override string ToString();
    }
}
