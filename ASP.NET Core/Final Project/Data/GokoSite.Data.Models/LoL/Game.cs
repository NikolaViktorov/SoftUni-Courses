using System;
using System.Collections.Generic;
using System.Text;

namespace GokoSite.Data.Models.LoL
{
    public class Game
    {
        public Game()
        {
            this.Teams = new List<Team>();
            this.UserGames = new HashSet<UserGames>();
        }

        public int GameId { get; set; }

        public long RiotGameId { get; set; }

        public virtual List<Team> Teams { get; set; }

        public virtual ICollection<UserGames> UserGames { get; set; }

    }
}
