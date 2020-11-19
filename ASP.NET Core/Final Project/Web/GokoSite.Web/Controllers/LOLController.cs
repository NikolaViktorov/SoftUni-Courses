namespace Suls.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using GokoSite.Services.Data;
    using GokoSite.Web.ViewModels.Games;
    using Microsoft.AspNetCore.Mvc;

    public class LOLController : Controller
    {
        private readonly IGamesService gamesService;
        private readonly INewsService newsService;
        private readonly IRegionsService regionsService;

        public LOLController(
            IGamesService gamesService,
            INewsService newsService,
            IRegionsService regionsService)
        {
            this.gamesService = gamesService;
            this.newsService = newsService;
            this.regionsService = regionsService;
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

        public async Task<IActionResult> lolapp()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var regions = await this.regionsService.GetRegions();
            this.ViewBag.Regions = regions;

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
                viewModel = this.gamesService.GetModelByMatches(games, input.RegionId);
            }
            catch (System.Exception e)
            {
                if (e.Message == "404, Resource not found")
                {
                    this.ModelState.AddModelError("lol", "There are no results recorded for the given Username.");
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
        public async Task<IActionResult> AddToCollection(long gameId, int regionId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userGameCount = this.gamesService.GetGameCount(userId);

            if (userGameCount < 10 )
            {
                await this.gamesService.AddGameToCollection(gameId, regionId);
                this.gamesService.AddGameToUser(userId);
            }

            return this.Redirect("/LOL/Collection");
        }

        public async Task<IActionResult> CollectionDetails(long gameId, int regionId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = await this.gamesService.GetModelByGameId(gameId, regionId);

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

    public static class StringMethodExtensions
    {
        private static string _paraBreak = "\r\n\r\n";
        private static string _link = "<a href=\"{0}\">{1}</a>";
        private static string _linkNoFollow = "<a href=\"{0}\" rel=\"nofollow\">{1}</a>";

        public static string ToHtml(this string s)
        {
            return ToHtml(s, false);
        }

        public static string ToHtml(this string s, bool nofollow)
        {
            StringBuilder sb = new StringBuilder();

            int pos = 0;
            while (pos < s.Length)
            {
                // Extract next paragraph
                int start = pos;
                pos = s.IndexOf(_paraBreak, start);
                if (pos < 0)
                    pos = s.Length;
                string para = s.Substring(start, pos - start).Trim();

                // Encode non-empty paragraph
                if (para.Length > 0)
                    EncodeParagraph(para, sb, nofollow);

                // Skip over paragraph break
                pos += _paraBreak.Length;
            }
            // Return result
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a single paragraph to HTML.
        /// </summary>
        /// <param name="s">Text to encode</param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        private static void EncodeParagraph(string s, StringBuilder sb, bool nofollow)
        {
            // Start new paragraph
            sb.AppendLine("<p>");

            // HTML encode text
            s = HttpUtility.HtmlEncode(s);

            // Convert single newlines to <br>
            s = s.Replace(Environment.NewLine, "<br />\r\n");

            // Encode any hyperlinks
            EncodeLinks(s, sb, nofollow);

            // Close paragraph
            sb.AppendLine("\r\n</p>");
        }

        /// <summary>
        /// Encodes [[URL]] and [[Text][URL]] links to HTML.
        /// </summary>
        /// <param name="text">Text to encode</param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        private static void EncodeLinks(string s, StringBuilder sb, bool nofollow)
        {
            // Parse and encode any hyperlinks
            int pos = 0;
            while (pos < s.Length)
            {
                // Look for next link
                int start = pos;
                pos = s.IndexOf("[[", pos);
                if (pos < 0)
                    pos = s.Length;
                // Copy text before link
                sb.Append(s.Substring(start, pos - start));
                if (pos < s.Length)
                {
                    string label, link;

                    start = pos + 2;
                    pos = s.IndexOf("]]", start);
                    if (pos < 0)
                        pos = s.Length;
                    label = s.Substring(start, pos - start);
                    int i = label.IndexOf("][");
                    if (i >= 0)
                    {
                        link = label.Substring(i + 2);
                        label = label.Substring(0, i);
                    }
                    else
                    {
                        link = label;
                    }
                    // Append link
                    sb.Append(String.Format(nofollow ? _linkNoFollow : _link, link, label));

                    // Skip over closing "]]"
                    pos += 2;
                }
            }
        }
    }

}
