using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Data.LoL
{
    public class UserGames
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
