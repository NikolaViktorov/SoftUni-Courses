using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = (decimal)3.50;
        public double Caffeine { get; set; }

        public Coffee(string name, decimal price, double milliliters) :base(name, price, milliliters)
        {

        }
    }
}
