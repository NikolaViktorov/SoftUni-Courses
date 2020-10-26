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
            this.UserGames = new HashSet<UserGames>();
        }

        public int GameId { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<UserGames> UserGames { get; set; }

    }
}
