namespace GokoSite.Services.Data
{
    using System.Threading.Tasks;

    public interface IAuthorizationsService
    {
        public Task AddAdministrator(string userId);

        public bool IsUserAdministrator(string userId);
    }
}
