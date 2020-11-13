﻿namespace Suls.Controllers
{
    using GokoSite.Services.Data;
    using GokoSite.Web.ViewModels.Forums;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class RPController : Controller
    {
        private readonly IRPServerService rPServerService;
        private readonly IForumsService forumsService;

        public RPController(IRPServerService rPServerService, IForumsService forumsService)
        {
            this.rPServerService = rPServerService;
            this.forumsService = forumsService;
        }

        public IActionResult Home()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult Rules()
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

        // Forum Routes

        public IActionResult Forum()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = this.forumsService.GetAll(userId);

            return this.View(viewModel);
        }

        public IActionResult MyForums()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = this.forumsService.GetPersonalPosts(userId);

            return this.View(viewModel);
        }

        public IActionResult AddForum()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddForum(string topic, string text)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AddForumModel inputModel = new AddForumModel()
            {
                ForumTopic = topic,
                ForumText = text,
                Likes = 0,
            };

            string forumId = await this.forumsService.AddPost(inputModel);
            await this.forumsService.AddPostToUser(userId, forumId);

            return this.Redirect("/RP/Forum");
        }

        public async Task<IActionResult> Like(string id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.forumsService.Like(id, userId);

            return this.Redirect("/RP/Forum");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            await this.forumsService.DeletePost(id);

            return this.Redirect("/RP/MyForums");
        }

        public IActionResult Edit(string id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = this.forumsService.GetPost(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(string id, string topic, string text, int likes)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var newPost = new AddForumModel()
            {
                ForumId = id,
                ForumText = text,
                ForumTopic = topic,
                Likes = likes,
            };

            await this.forumsService.EditPost(newPost);

            return this.Redirect("/RP/MyForums");
        }
    }
}