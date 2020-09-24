using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; set; }

        public bool CanParticipate => this.Motorcycle != null;

        public Rider(string name)
        {
            this.Name = name;
            NumberOfWins = 0;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), "Motorcycle cannot be null.");
            }
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            NumberOfWins++;            
        }
    }
}
