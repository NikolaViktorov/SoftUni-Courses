﻿namespace GokoSite.Web.ViewModels.Games
{
    using GokoSite.Web.ViewModels.Games.DTOs;

    public class HomePageGameViewModel
    {
        public long GameId { get; set; }

        public TeamDTO BlueTeam { get; set; }

        public TeamDTO RedTeam { get; set; }
    }
}