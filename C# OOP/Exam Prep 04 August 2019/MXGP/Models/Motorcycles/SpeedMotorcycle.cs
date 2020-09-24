using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        int horsePower;
        const int SpeedMotorcycleCubicCentimiters = 125;
        const int MinimumHorsePower = 50;
        const int MaximumHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, SpeedMotorcycleCubicCentimiters)
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
