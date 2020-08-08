using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public Gladiator(string Name, Stat Stat, Weapon Weapon)
        {
            this.Name = Name;
            this.Stat = Stat;
            this.Weapon = Weapon;
        }

        // return the sum of the stat properties plus the sum of the weapon properties
        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }
        // return the sum of the weapon properties.
        public int GetWeaponPower()
        {
            int power = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            return power;
        }
        // return the sum of the stat properties.
        public int GetStatPower()
        {
            int power = this.Stat.Agility + this.Stat.Flexibility 
                + this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength;
            return power;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            builder.AppendLine($"  Weapon Power: {this.GetWeaponPower()}");
            builder.AppendLine($"  Stat Power: {this.GetStatPower()}");

            return builder.ToString();
        }
    }
}
