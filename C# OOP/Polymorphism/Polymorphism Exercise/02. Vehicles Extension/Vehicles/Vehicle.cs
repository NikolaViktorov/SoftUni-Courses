using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public abstract class Vehicle
    {
        abstract public double TankCapacity { get; set; }
        abstract public double FuelQuantity { get; set; }
        abstract public double FuelConsumptionInLitersPerKm { get; set; }

        abstract public void Drive(double distance);
        abstract public void Refill(double fuel);
        public abstract override string ToString();
    }
}
