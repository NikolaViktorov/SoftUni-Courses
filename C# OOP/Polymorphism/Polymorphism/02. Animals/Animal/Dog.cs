using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }
        public override string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}" + Environment.NewLine + "DJAAF";
        }
    }
}
