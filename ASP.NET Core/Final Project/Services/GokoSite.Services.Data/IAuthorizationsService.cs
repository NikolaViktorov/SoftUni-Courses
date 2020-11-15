namespace GokoSite.Services.Data
{
    public interface IAuthorizationsService
    {
        public bool IsUserAdministrator(string userId);
    }
}
