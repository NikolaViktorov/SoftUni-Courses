using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Wild_Farm.Food
{
    public class Fruit : Food
    {
        public override int Quantity { get; set; }

        public Fruit(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
