namespace GokoSite.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using GokoSite.Data;

    public class AuthorizationsService : IAuthorizationsService
    {
        private readonly ApplicationDbContext db;

        public AuthorizationsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAdministrator(string userId)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
            var administratorRole = this.db.Roles.FirstOrDefault(r => r.Name == "Administrator");

            if (user != null && administratorRole != null)
            {
                this.db.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>()
                {
                    RoleId = administratorRole.Id,
                    UserId = user.Id,
                });

                await this.db.SaveChangesAsync();
            }
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
