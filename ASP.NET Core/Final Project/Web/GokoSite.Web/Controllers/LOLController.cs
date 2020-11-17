namespace Suls.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GokoSite.Services.Data;
    using GokoSite.Web.ViewModels.Games;
    using Microsoft.AspNetCore.Mvc;

    public class LOLController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly INewsService newsService;

        public LOLController(
            IGamesService gamesService,
            INewsService newsService)
        {
            this.gamesService = gamesService;
            this.newsService = newsService;
        }

        public IActionResult Home()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = this.newsService.GetNews();

            return this.View(viewModel);
        }

        public IActionResult lolapp()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public async Task<IActionResult> GetGames(GetGamesInputModel input)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            IEnumerable<HomePageGameViewModel> viewModel = new List<HomePageGameViewModel>();

            try
            {
                var games = await this.gamesService.GetGamesAsync(input);
                viewModel = this.gamesService.GetModelByMatches(games);
            }
            catch (System.Exception e)
            {
                if (e.Message == "404, Resource not found")
                {
                    this.ModelState.AddModelError("lol", "There are no results recorded.");
                }
                else
                {
                    this.ModelState.AddModelError("lol", e.Message);
                }
            }

            if (!this.ModelState.IsValid)
            {
                return this.View("lolapp");
            }

            return this.View("games", viewModel);
        }

        public IActionResult Collection()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = this.gamesService.GetCollectionGames(userId);

            return this.View(viewModel);
        }

        // add
        public IActionResult AddToCollection(long gameId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userGameCount = this.gamesService.GetGameCount(userId);

            if (userGameCount < 10 )
            {
                this.gamesService.AddGameToCollection(gameId);
                this.gamesService.AddGameToUser(userId);
            }

            return this.Redirect("/LOL/Collection");
        }

        public IActionResult CollectionDetails(long gameId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = this.gamesService.GetModelByGameId(gameId).GetAwaiter().GetResult();

            return this.View(viewModel);
        }

        public IActionResult Remove(long gameId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.gamesService.RemoveGameFromCollection(userId, gameId);

            return this.Redirect("/LOL/Collection");
        }

        public IActionResult New(string newId)
        {
            var viewModel = this.newsService.GetNew(newId);

            return this.View(viewModel);
        }
    }
}
