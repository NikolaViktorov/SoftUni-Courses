using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Data.LoL
{
    public class Game
    {
        public Game()
        {
            this.Teams = new HashSet<Team>();
        }

        public int GameId { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
