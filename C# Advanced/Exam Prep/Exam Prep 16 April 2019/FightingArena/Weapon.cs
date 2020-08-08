using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Weapon
    {
        public int Size { get; set; }
        public int Solidity { get; set; }
        public int Sharpness { get; set; }

        public Weapon(int Size, int Solidity, int Sharpness)
        {
            this.Size = Size;
            this.Solidity = Solidity;
            this.Sharpness = Sharpness;
        }
    }
}
