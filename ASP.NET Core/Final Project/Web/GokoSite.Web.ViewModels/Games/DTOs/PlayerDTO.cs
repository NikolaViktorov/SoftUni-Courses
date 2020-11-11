namespace GokoSite.Web.ViewModels.Games.DTOs
{
    public class PlayerDTO
    {
        public string Username { get; set; }

        public string ProfileIconUrl { get; set; }

        public ChampionDTO Champion { get; set; }
    }
}
