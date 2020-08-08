using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Stat
    {
        public int Strength { get; set; }
        public int Flexibility { get; set; }
        public int Agility { get; set; }
        public int Skills { get; set; }
        public int Intelligence { get; set; }

        public Stat(int Strength, int Flexibility, int Agility, int Skills, int Intelligence)
        {
            this.Strength = Strength;
            this.Flexibility = Flexibility;
            this.Agility = Agility;
            this.Skills = Skills;
            this.Intelligence = Intelligence;
        }
    }
}
