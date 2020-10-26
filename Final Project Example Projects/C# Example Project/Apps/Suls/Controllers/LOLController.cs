using Suls.Services;
using Suls.ViewModels.Games;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Controllers
{
    public class LOLController : Controller
    {
        private readonly IGamesService gamesService;

        public LOLController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public HttpResponse lolapp()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse GetGames(string username, int count)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var games = gamesService.GetGamesAsync(username, count).GetAwaiter().GetResult();
            var viewModel = this.gamesService.GetModelByGames(games);

            return this.View(viewModel, "games");
        }

        public HttpResponse Details(long gameId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.gamesService.GetModelByGameId(gameId).GetAwaiter().GetResult();

            return this.View(viewModel);
        }

        public HttpResponse Collection(long gameId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.gamesService.AddGameToCollection(gameId);

            return this.Redirect("/LOL/Collection");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
