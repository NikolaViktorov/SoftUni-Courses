using RiotSharp.Endpoints.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Games
{
    public class HomePageGameViewModel
    {
        public long GameId { get; set; }

        public TeamDTO BlueTeam { get; set; }

        public TeamDTO RedTeam { get; set; }
    }
}
