using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Military_Elite.Privates.SpecialisedSoldier.Commando
{
    public class Mission
    {
        public string CodeName { get; set; }
        public bool IsFinished { get; set; }

        public void CompleteMission()
        {
            this.IsFinished = true;
        }
    }
}
