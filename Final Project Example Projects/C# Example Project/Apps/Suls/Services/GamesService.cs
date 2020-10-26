using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;
using Suls.Data;
using Suls.Data.LoL;
using Suls.Services.StaticData;
using Suls.ViewModels.Games;
using Suls.ViewModels.Games.DTOs;

namespace Suls.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext db;
        private readonly IChampionsService championsService;
        private readonly IPlayersService playersService;

        private string ddVersion { get; set; }

        Region region = Region.Eune;

        public RiotApi api { get; set; }

        public GamesService(ApplicationDbContext db, IChampionsService championsService, IPlayersService playersService)
        {
            this.db = db;
            this.championsService = championsService;
            this.playersService = playersService;
            this.api = RiotApi.GetDevelopmentInstance(PublicData.apiKey);
            this.ddVersion = PublicData.ddVerision;
        }

        public async Task<Summoner> GetBasicSummonerDataAsync(string summonerName)
        {
            var summoner = await api.Summoner.GetSummonerByNameAsync(region, summonerName);

            return summoner;
        }

        public async Task<Match> GetGameAsync(long gameId)
        {
            var game = await this.api.Match.GetMatchAsync(region, gameId);

            return game;
        }

        public async Task<ICollection<Match>> GetGamesAsync(string summonerName, int count)
        {
            var summoner = await GetBasicSummonerDataAsync(summonerName);

            var matches = await api.Match.GetMatchListAsync(region, summoner.AccountId);

            var games = new List<Match>();

            for (int i = 0; i < count; i++)
            {
                var game = await GetGameAsync(matches.Matches[i].GameId);

                games.Add(game);
            }

            return games;
        }

        public IEnumerable<HomePageGameViewModel> GetModelByGames(ICollection<Match> games)
        {
            var viewModel = new List<HomePageGameViewModel>();

            foreach (var game in games)
            {
                viewModel.Add(new HomePageGameViewModel
                {
                    GameId = game.GameId,
                    BlueTeam = new TeamDTO
                    {
                        Players = this.playersService.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 100),
                        State = game.Teams[0].Win
                    },
                    RedTeam = new TeamDTO
                    {
                        Players = this.playersService.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 200),
                        State = game.Teams[1].Win
                    }
                });
            }

            return viewModel.ToList();
        }

        public async Task<HomePageGameViewModel> GetModelByGameId(long gameId) // More eficient..
        {
            var game = await api.Match.GetMatchAsync(region, gameId);

            var viewModel = new HomePageGameViewModel
            {
                GameId = game.GameId,
                BlueTeam = new TeamDTO
                {
                    Players = this.playersService.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 100),
                    State = game.Teams[0].Win
                },
                RedTeam = new TeamDTO
                {
                    Players = this.playersService.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 200),
                    State = game.Teams[1].Win
                }
            };

            return viewModel;
        }

        // UPDATE NEEDED 100% TODO - DONT REQUEST ALL CHAMPS
        public void AddGameToCollection(long gameId) // Update FOR COLLECTION TO WORK
        {
            var curGame = GetGameAsync(gameId).GetAwaiter().GetResult();

            var game = new Game();

            var firstTeam = new Team
            {
                State = curGame.Teams[0].Win
            };

            var secondTeam = new Team
            {
                State = curGame.Teams[1].Win
            };

            game.Teams.Add(firstTeam);
            game.Teams.Add(secondTeam);

            this.db.Games.Add(game);
            this.db.SaveChanges();

            var dbGame = this.db.Games.OrderByDescending(g => g.GameId).FirstOrDefault();

            var firstTeamId = dbGame.Teams[0].TeamId;
            var secondTeamId = dbGame.Teams[1].TeamId;


            var firstTeamPlayers = playersService.GetPlayersByParticipants(curGame.ParticipantIdentities, curGame.Participants, 100).ToList();
            // 100 first team / 200 second team
            var secondTeamPlayers = playersService.GetPlayersByParticipants(curGame.ParticipantIdentities, curGame.Participants, 200).ToList();

            firstTeamPlayers.ForEach(p => p.TeamId = firstTeamId);
            secondTeamPlayers.ForEach(p => p.TeamId = secondTeamId);

            foreach (var player in firstTeamPlayers)
            {
                this.db.Players.Add(player);
            }

            foreach (var player in secondTeamPlayers)
            {
                this.db.Players.Add(player);
            }

            this.db.SaveChanges();

            var players = this.db.Players.Where(p => p.TeamId == firstTeamId || p.TeamId == secondTeamId).Select(p => p).ToList();
            var champions = this.db.ChampionsStatic.ToList();

            for (int i = 0; i < players.Count; i++)
            {
                var playerId = players[i].PlayerId;
                var champRiotId = curGame.Participants[i].ChampionId;
                var champId = champions.FirstOrDefault(c => c.ChampionRiotId == champRiotId.ToString()).ChampionId;

                this.db.PlayerChampion.Add(new PlayerChampion
                {
                    PlayerId = playerId,
                    ChampionId = champId
                });
            }

            this.db.SaveChanges();

            Console.WriteLine();
        }

        public void AddGameToUser(string userId)
        {
            var dbGame = this.db.Games.OrderByDescending(g => g.GameId).FirstOrDefault();

            this.db.UserGames.Add(new UserGames
            {
                UserId = userId,
                GameId = dbGame.GameId
            });
            this.db.SaveChanges();
        }

        public int GetGameCount(string userId)
        {
            return this.db.UserGames.Where(u => u.UserId == userId).Count();
        }
    }
}
