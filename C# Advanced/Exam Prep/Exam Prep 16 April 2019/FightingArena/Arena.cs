using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        //List<Gladiator> Gladiators { get; set; } - сгрешено


        //-Field gladiators – collection that holds added gladiators - по условие
        private List<Gladiator> gladiators;

        // public int Count { get; private set; } - грешно, виж по долу

        public string Name { get; private set; }

        public Arena(string name)  // имената на променливите тук по конвенция са с малки букви, поправи ги и в др. класове
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }

        //Getter Count – returns the number of stored heroes. - по условие, означава следното:
        public int Count => this.gladiators.Count();

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
            //Count = Gladiators.Count; - грешно
        }
        public void Remove(string name)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].Name == name)
                {
                    gladiators.RemoveAt(i);
                    //Count = Gladiators.Count; - грешно
                }
            }
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator highestTotal = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetTotalPower() > highestTotal.GetTotalPower())
                {
                    highestTotal = glad;
                }
            }
            return highestTotal;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator highestWeapon = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetWeaponPower() > highestWeapon.GetWeaponPower())
                {
                    highestWeapon = glad;
                }
            }
            return highestWeapon;
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator highestStat = gladiators[0];

            foreach (var glad in gladiators)
            {
                if (glad.GetStatPower() > highestStat.GetStatPower())
                {
                    highestStat = glad;
                }
            }
            return highestStat;
        }
        public override string ToString()
        {
            return $"{this.Name} - {gladiators.Count} gladiators are participating.";
        }
    }
}