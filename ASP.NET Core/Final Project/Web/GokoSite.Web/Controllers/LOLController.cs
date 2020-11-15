﻿namespace Suls.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GokoSite.Services.Data;
    using GokoSite.Web.ViewModels.Games;
    using GokoSite.Web.ViewModels.News;
    using Microsoft.AspNetCore.Mvc;

    public class LOLController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly IAuthorizationsService authorizationsService;
        private readonly INewsService newsService;

        public LOLController(
            IGamesService gamesService,
            IAuthorizationsService authorizationsService,
            INewsService newsService)
        {
            this.gamesService = gamesService;
            this.authorizationsService = authorizationsService;
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

        public async Task<IActionResult> GetGames(string username, string count)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            if (int.TryParse(count, out int countNum) == false)
            {
                this.ModelState.AddModelError("count", "Count must be a number");
            }
            else if (countNum < 1 || countNum > 10)
            {
                this.ModelState.AddModelError("count", "Count must be between 1 and 10!");
            }

            if (string.IsNullOrEmpty(username) || username.Length > 16)
            {
                this.ModelState.AddModelError("username", "Username must be between 1 and 16 characters long!");
            }

            IEnumerable<HomePageGameViewModel> viewModel = new List<HomePageGameViewModel>();

            try
            {
                var games = await this.gamesService.GetGamesAsync(username, countNum);
                viewModel = this.gamesService.GetModelByMatches(games);
            }
            catch (System.Exception e)
            {
                this.ModelState.AddModelError("lol", e.Message);
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

        public IActionResult AddNew()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/LOL/Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(NewAddInputModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/LOL/Home");
            }

            // input validations....
            if (string.IsNullOrEmpty(input.Title) || input.Title.Length <= 0)
            {
                // error
            }

            await this.newsService.AddNew(input, userId);

            return this.Redirect("/LOL/Home");
        }

        public IActionResult New(string newId)
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);

            var viewModel = this.newsService.GetNew(newId, userName);

            return this.View(viewModel);
        }
    }
}
