using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using Suls.Data.LoL;
using Suls.ViewModels.Games;
using Suls.ViewModels.Games.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suls.Services
{
    public interface IGamesService
    {
        Task<ICollection<Match>> GetGamesAsync(string summonerName, int count);

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
