using Suls.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IRPServerService
    {
        public HomePageViewModel GetPlayers();
    }
}
