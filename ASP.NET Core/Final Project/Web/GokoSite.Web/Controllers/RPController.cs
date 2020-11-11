namespace Suls.Controllers
{
    using GokoSite.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class RPController : Controller
    {
        private readonly IRPServerService rPServerService;

        public RPController(IRPServerService rPServerService)
        {
            this.rPServerService = rPServerService;
        }

        public IActionResult Home()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult Players()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = this.rPServerService.GetPlayers();

            return this.View(viewModel);
        }

        public IActionResult Rules()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult WhitelistApps()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult PoliceWhitelist()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult ServerWhitelist()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }
    }
}
