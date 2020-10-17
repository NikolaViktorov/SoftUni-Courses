using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsServices, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsServices;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                Name = this.problemsService.GetNameById(id),
                ProblemId = id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters!");
            }
            
            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);

            return this.Redirect("/");
        }
        
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
