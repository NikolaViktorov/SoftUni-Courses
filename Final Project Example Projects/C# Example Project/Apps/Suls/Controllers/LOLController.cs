using RiotSharp.Endpoints.MatchEndpoint;
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
            var viewModel = this.gamesService.GetModelByMatches(games);

            return this.View(viewModel, "games");
        }

        // TODO Remove Details if not in collection
        public HttpResponse Details(long gameId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.gamesService.GetModelByGameId(gameId).GetAwaiter().GetResult();

            return this.View(viewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var viewModel = gamesService.GetCollectionGames(userId);

            return this.View(viewModel);
        }

        // add
        public HttpResponse AddToCollection(long gameId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var userGameCount = gamesService.GetGameCount(userId);

            if (userGameCount < 10 )
            {
                this.gamesService.AddGameToCollection(gameId);
                this.gamesService.AddGameToUser(userId);
            }
            else
            {
                return this.Error("You already have the max of 10 games in your collection.");
            }

            return this.Redirect("/LOL/Collection");
        }

        public HttpResponse CollectionDetails(long gameId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.gamesService.GetModelByGameId(gameId).GetAwaiter().GetResult();

            return this.View(viewModel);
        }
    }
}
