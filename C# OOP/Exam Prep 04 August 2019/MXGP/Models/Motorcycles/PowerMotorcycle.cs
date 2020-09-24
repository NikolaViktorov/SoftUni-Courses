using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        int horsePower;
        const int PowerMotorcycleCubicCentimiters = 450;
        const int MinimumHorsePower = 70;
        const int MaximumHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, PowerMotorcycleCubicCentimiters)
        { 
        }
        
        public override int HorsePower
        {
            get
            {
                return horsePower;
            }
            protected set
            {
                if (value < MinimumHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
