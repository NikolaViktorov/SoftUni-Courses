using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Games.DTOs
{
    public class PlayerDTO
    {
        public string Username { get; set; }

        public string ProfileIconUrl { get; set; }

        public ChampionDTO Champion { get; set; }
    }
}
