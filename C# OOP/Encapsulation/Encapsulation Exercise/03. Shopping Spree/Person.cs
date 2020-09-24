using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        string name;
        decimal money;
        List<Product> products;

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
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public Person(string name, decimal money)
        {
            this.Money = money;
            this.Name = name;
            this.products = new List<Product>();
        }
        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                products.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }
        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.products)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
