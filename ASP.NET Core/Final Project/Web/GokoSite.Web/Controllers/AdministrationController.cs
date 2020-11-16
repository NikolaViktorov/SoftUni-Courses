namespace GokoSite.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GokoSite.Services.Data;
    using GokoSite.Web.ViewModels.News;
    using Microsoft.AspNetCore.Mvc;

    public class AdministrationController : Controller
    {
        private readonly IAuthorizationsService authorizationsService;
        private readonly INewsService newsService;

        public AdministrationController(
            IAuthorizationsService authorizationsService,
            INewsService newsService)
        {
            this.authorizationsService = authorizationsService;
            this.newsService = newsService;
        }

        public IActionResult AdminPanel()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        public IActionResult AddAdmin()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(string userId)
        {
            var curUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(curUserId);

            if (!isAdministrator)
            {
                return this.Redirect("/");
            }

            await this.authorizationsService.AddAdministrator(userId);

            return this.Redirect("/");
        }

        public IActionResult AddNew()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/");
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
                return this.Redirect("/");
            }

            // input validations....
            if (string.IsNullOrEmpty(input.Title) || input.Title.Length <= 0)
            {
                // error
            }

            await this.newsService.AddNew(input, userId);

            return this.Redirect("/LOL/Home");
        }

        public async Task<IActionResult> RemoveNew(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdministrator = this.authorizationsService.IsUserAdministrator(userId);

            if (!isAdministrator)
            {
                return this.Redirect("/");
            }

            var isDeleted = await this.newsService.RemoveNew(id);
            return this.Redirect("/LOL/Home");
        }
    }
}
