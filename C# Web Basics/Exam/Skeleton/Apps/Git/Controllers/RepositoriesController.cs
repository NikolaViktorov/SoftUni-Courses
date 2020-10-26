using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var reposViewModel = this.repositoriesService.GetPublic();

            var userId = this.GetUserId();

            if (userId != null)
            {
                var privateRepos = this.repositoriesService.GetPrivate(userId);
                foreach (var repo in privateRepos)
                {
                   reposViewModel.Add(repo);
                }
            }

            return this.View(reposViewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Name should be between 3 and 20 characters.");
            }
            if (string.IsNullOrEmpty(repositoryType) || (repositoryType != "Public" && repositoryType != "Private"))
            {
                return this.Error("Invalid repository type.");
            }

            var userId = this.GetUserId();

            this.repositoriesService.Create(name, repositoryType, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}
