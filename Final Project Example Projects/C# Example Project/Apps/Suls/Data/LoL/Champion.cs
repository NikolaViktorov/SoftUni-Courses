using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Data.LoL
{
    public class Champion
    {
        [Key]
        public int ChampionId { get; set; }

        public string ChampionName { get; set; }

        public string ChampionIconUrl { get; set; }

        public string ChampionRiotId { get; set; }
    }
}
