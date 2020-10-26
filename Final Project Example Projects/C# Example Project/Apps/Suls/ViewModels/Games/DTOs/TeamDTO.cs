using RiotSharp.Endpoints.MatchEndpoint;
using Suls.ViewModels.Games.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Games
{
    public class TeamDTO
    {
        public List<PlayerDTO> Players { get; set; }

        public string State { get; set; }
    }
}
