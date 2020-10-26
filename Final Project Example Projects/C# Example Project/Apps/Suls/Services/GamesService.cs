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

        private string ddVersion { get; set; }

        Region region = Region.Eune;

        public RiotApi api { get; set; }

        public GamesService(ApplicationDbContext db, IChampionsService championsService)
        {
            this.db = db;
            this.championsService = championsService;
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
                        Players = this.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 100),
                        State = game.Teams[0].Win
                    },
                    RedTeam = new TeamDTO
                    {
                        Players = this.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 200),
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
                    Players = this.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 100),
                    State = game.Teams[0].Win
                },
                RedTeam = new TeamDTO
                {
                    Players = this.GetPlayersByParticipantsDto(game.ParticipantIdentities, game.Participants, 200),
                    State = game.Teams[1].Win
                }
            };

            return viewModel;
        }

        // UPDATE NEEDED 100% TODO - DONT REQUEST ALL CHAMPS
        public void AddGameToCollection(long gameId) // Update FOR COLLECTION TO WORK
        {
            // 
        }

        private ICollection<Data.LoL.Player> GetPlayersByParticipants(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
        {
            var players = new List<Data.LoL.Player>();

            for (int i = 0; i < participants.Count; i++)
            {
                if (teamId == participants[i].TeamId && participants[i].ParticipantId == participantIdentities[i].ParticipantId)
                {
                    players.Add(new Data.LoL.Player
                    {
                        Username = participantIdentities[i].Player.SummonerName,
                        ProfileIconUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.ddVersion}/img/profileicon/{participantIdentities[i].Player.ProfileIcon}.png",
                    });
                }
            }

            return players;
        }
       
        private List<PlayerDTO> GetPlayersByParticipantsDto(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
        {
            var players = new List<PlayerDTO>();

            for (int i = 0; i < participants.Count; i++)
            {
                if (teamId == participants[i].TeamId && participants[i].ParticipantId == participantIdentities[i].ParticipantId)
                {
                    players.Add(new PlayerDTO
                    {
                        Username = participantIdentities[i].Player.SummonerName,
                        ProfileIconUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.ddVersion}/img/profileicon/{participantIdentities[i].Player.ProfileIcon}.png",
                        Champion = championsService.GetChampionDto(participants[i].ChampionId).GetAwaiter().GetResult()
                    });
                }
            }

            return players;
        }
    }
}
