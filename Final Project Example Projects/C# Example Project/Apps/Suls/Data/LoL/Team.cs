using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Data.LoL
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

        public ICollection<Player> Players { get; set; }

        public string State { get; set; }
    }
}
