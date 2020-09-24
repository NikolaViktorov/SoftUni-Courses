using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        string name;
        decimal cost;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }
        public Product(string name, decimal cost)
        {
            this.Cost = cost;
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
