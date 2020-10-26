using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Data.LoL
{
    public class Player
    {
        public Player()
        {
            this.PlayerChampions = new HashSet<PlayerChampion>();
        }

        public int PlayerId { get; set; }

        public string Username { get; set; }

        public string ProfileIconUrl { get; set; }

        public int TeamId { get; set; }

        public ICollection<PlayerChampion> PlayerChampions { get; set; }
    }
}
