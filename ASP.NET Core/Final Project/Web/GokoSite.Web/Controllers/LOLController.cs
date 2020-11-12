namespace Suls.Controllers
{
    using GokoSite.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class LOLController : Controller
    {
        private readonly IGamesService gamesService;

        public LOLController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Home()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
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

            if (!this.ModelState.IsValid)
            {
                return this.View("lolapp");
            }

            var games = await this.gamesService.GetGamesAsync(username, countNum);
            var viewModel = this.gamesService.GetModelByMatches(games);

            return this.View("games", viewModel);
        }

        // TODO Remove Details if not in collection
        public IActionResult Details(long gameId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = this.gamesService.GetModelByGameId(gameId).GetAwaiter().GetResult();

            return this.View(viewModel);
        }

        public IActionResult Collection()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = gamesService.GetCollectionGames(userId);

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

            var userGameCount = gamesService.GetGameCount(userId);

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
    }
}
