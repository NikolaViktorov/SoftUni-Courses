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
using Suls.ViewModels.Games;
using Suls.ViewModels.Games.DTOs;

namespace Suls.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext db;

        public const string apiKey = "RGAPI-41eca856-e4e7-4eb7-90a6-6e5867de3057";

        public const Region region = Region.Eune; // change to choice

        private string ddVersion { get; set; }

        public RiotApi api { get; set; }

        public GamesService(ApplicationDbContext db)
        {
            this.db = db;
            this.api = RiotApi.GetDevelopmentInstance(apiKey);
            this.ddVersion = GetLatestVersion();
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
            var game = api.Match.GetMatchAsync(region, gameId).GetAwaiter().GetResult();

            //var curGame = new Data.LoL.Game
            //{
            //    Teams = new List<Team>
            //    {
            //        new Team
            //        {
            //            Players = this.GetPlayersByParticipants(game.ParticipantIdentities, game.Participants, 100),
            //            State = game.Teams[0].Win
            //        },
            //        new Team
            //        {
            //            Players = this.GetPlayersByParticipants(game.ParticipantIdentities, game.Participants, 200),
            //            State = game.Teams[1].Win
            //        },
            //    }
            //};

            var playerst1 = this.GetPlayersByParticipants(game.ParticipantIdentities, game.Participants, 100).ToList();
            var playerst2 = this.GetPlayersByParticipants(game.ParticipantIdentities, game.Participants, 200).ToList();

            this.db.Players.AddRange(playerst1);
            this.db.Players.AddRange(playerst2);

            this.db.SaveChanges();
        }

        private async Task<Champion> GetChampion(int championId)
        {
            if (this.db.ChampionsStatic.ToList().Count == 0)
            {
                await UploadChamionsToDBAsync();
            }

            var champion = this.db.ChampionsStatic.FirstOrDefault(c => c.ChampionId == championId);

            return champion;
        }

        private async Task<ChampionDTO> GetChampionDto(int championId)
        {
            if (this.db.ChampionsStatic.ToList().Count == 0)
            {
                await UploadChamionsToDBAsync();
            }

            var champion = this.db.ChampionsStatic
                .Where(c => c.ChampionRiotId == championId.ToString())
                .Select(c => new ChampionDTO
                {
                    ChampionIconUrl = c.ChampionIconUrl,
                    ChampionName = c.ChampionName
                })
                .FirstOrDefault();

            return champion;
        }

        private async Task UploadChamionsToDBAsync()
        {
            var dic = await api.StaticData.Champions.GetAllAsync(this.ddVersion);
            var champions = dic.Champions.Values;

            foreach (var champ in champions)
            {
                var champion = new Champion
                {
                    ChampionName = champ.Name,
                    ChampionIconUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.ddVersion}/img/champion/{champ.Image.Full}",
                    ChampionRiotId = champ.Id.ToString()
                };

                this.db.ChampionsStatic.Add(champion);
            }

            await this.db.SaveChangesAsync();
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

        private string GetLatestVersion()
        {
            string url = "https://ddragon.leagueoflegends.com/api/versions.json";
            var req = (HttpWebRequest)WebRequest.Create(url);
            var latestVersion = string.Empty;

            req.Method = "GET";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                if (res.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + res.StatusCode);
                }

                using (Stream resStream = res.GetResponseStream())
                {
                    if (resStream != null)
                    {
                        using (StreamReader reader = new StreamReader(resStream))
                        {
                            string[] result = reader.ReadToEnd().Split(new char[] { '[', ']', '\\', '\"', '{', '}', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                            latestVersion = result[0];
                        }
                    }
                }
            }

            return latestVersion;
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
                        Champion = GetChampionDto(participants[i].ChampionId).GetAwaiter().GetResult()
                    });
                }
            }

            return players;
        }


    }
}
