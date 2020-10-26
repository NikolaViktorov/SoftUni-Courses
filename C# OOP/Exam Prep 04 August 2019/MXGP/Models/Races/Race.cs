﻿using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        int laps;
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }
        public int Laps
        {
            get
            {
                return laps;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                laps = value;
            }
        }

        readonly List<IRider> riders;
        public IReadOnlyCollection<IRider> Riders
            => riders.AsReadOnly();

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), "Rider cannot be null.");
            }
            if (rider.CanParticipate == false)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            if (this.riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }
            riders.Add(rider);  
        }
    }
}