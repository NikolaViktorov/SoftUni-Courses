using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using Suls.ViewModels.Games;
using Suls.ViewModels.Games.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suls.Services
{
    public interface IGamesService
    {
        Task<ICollection<Match>> GetGamesAsync(string summonerName, int count);

        Task<Match> GetGameAsync(long gameId);

        Task<Summoner> GetBasicSummonerDataAsync(string summonerName);

        IEnumerable<HomePageGameViewModel> GetModelByGames(ICollection<Match> games);

        Task<HomePageGameViewModel> GetModelByGameId(long gameId);

        void AddGameToCollection(long gameId);

        void AddGameToUser(string userId);
        int GetGameCount(string userId);
        ICollection<Match> GetCollectionGames(string userId);
    }
}
