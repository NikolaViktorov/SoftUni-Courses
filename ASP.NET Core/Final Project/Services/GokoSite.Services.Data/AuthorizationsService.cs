namespace GokoSite.Services.Data
{
    using System.Linq;

    using GokoSite.Data;

    public class AuthorizationsService : IAuthorizationsService
    {
        private readonly ApplicationDbContext db;

        public AuthorizationsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool IsUserAdministrator(string userId)
        {
            var adminRole = this.db.Roles.FirstOrDefault(r => r.Name == "Administrator");
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            var isAdministrator = this.db.UserRoles.Any(ur => ur.UserId == userId && ur.RoleId == adminRole.Id);

            return isAdministrator;
        }
    }
}
