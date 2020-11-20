namespace GokoSite.Web.ViewModels.Games.DTOs
{
    public class PlayerDTO
    {
        public string Username { get; set; }

        public string ProfileIconUrl { get; set; }

        public string KDA { get; set; }

        public long Damage { get; set; }

        public string CS { get; set; }

        public ChampionDTO Champion { get; set; }
    }
}
