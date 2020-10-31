using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class RPController : Controller
    {
        private readonly IRPServerService rPServerService;

        public RPController(IRPServerService rPServerService)
        {
            this.rPServerService = rPServerService;
        }

        public HttpResponse Home()
        {
            if(!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.rPServerService.GetPlayers();

            return this.View(viewModel);
        }

        public HttpResponse Players()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.rPServerService.GetPlayers();

            return this.View(viewModel);
        }

        public HttpResponse Rules()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
