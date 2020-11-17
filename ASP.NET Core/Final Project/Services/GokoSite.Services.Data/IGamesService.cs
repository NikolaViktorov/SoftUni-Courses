namespace GokoSite.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GokoSite.Web.ViewModels.Games;
    using RiotSharp.Endpoints.MatchEndpoint;
    using RiotSharp.Endpoints.SummonerEndpoint;

    public interface IGamesService
    {
        Task<ICollection<Match>> GetGamesAsync(GetGamesInputModel input);

        ICollection<CollectionPageGameViewModel> GetCollectionGames(string userId);

        Task<Match> GetGameAsync(long gameId);

        Task<Summoner> GetBasicSummonerDataAsync(string summonerName);

        IEnumerable<HomePageGameViewModel> GetModelByMatches(ICollection<Match> games);

        Task<HomePageGameViewModel> GetModelByGameId(long gameId);

        void AddGameToCollection(long gameId);

        void AddGameToUser(string userId);

        void RemoveGameFromCollection(string userId, long gameId);

        int GetGameCount(string userId);
    }
}
