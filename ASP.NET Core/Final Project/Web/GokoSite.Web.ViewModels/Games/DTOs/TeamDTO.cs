namespace GokoSite.Web.ViewModels.Games.DTOs
{
    using System.Collections.Generic;

    public class TeamDTO
    {
        public List<PlayerDTO> Players { get; set; }

        public string State { get; set; }
    }
}
