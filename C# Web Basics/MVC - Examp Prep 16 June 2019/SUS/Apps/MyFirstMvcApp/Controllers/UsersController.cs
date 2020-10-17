using BattleCards.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;

        // GET /users/login
        public UsersController(IUsersService usersService)
        {
            this.userService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.userService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        // GET /users/register
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (username == null || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid Username. Length should be between 5 and 20 characters!");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid Username. Only alphanumeric characters allowed.");
            }

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email.");
            }

            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. Length should be between 6 and 20 characters!");
            }

            if (password != confirmPassword)
            {
                return this.Error("Passwords should match!");
            }

            if (this.userService.IsUsernameAvailable(username) == false)
            {
                return this.Error("An user with this username already exists!");
            }

            if (this.userService.IsEmailAvailable(email) == false)
            {
                return this.Error("An user with this email already exists!");
            }

            var userId = this.userService.CreateUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout!");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
