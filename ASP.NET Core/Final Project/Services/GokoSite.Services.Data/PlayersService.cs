﻿namespace GokoSite.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GokoSite.Services.Data.StaticData;
    using GokoSite.Web.ViewModels.Games.DTOs;
    using RiotSharp;
    using RiotSharp.Endpoints.MatchEndpoint;
    using RiotSharp.Misc;

    public class PlayersService : IPlayersService
    {
        private readonly string ddVersion;
        private readonly IChampionsService championsService;

        public PlayersService(IChampionsService championsService)
        {
            this.ddVersion = PublicData.ddVerision;
            this.championsService = championsService;
        }

        public ICollection<GokoSite.Data.Models.LoL.Player> GetPlayersByParticipants(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
        {
            var players = new List<GokoSite.Data.Models.LoL.Player>();

            for (int i = 0; i < participants.Count; i++)
            {
                if (teamId == participants[i].TeamId && participants[i].ParticipantId == participantIdentities[i].ParticipantId)
                {
                    players.Add(new GokoSite.Data.Models.LoL.Player
                    {
                        Username = participantIdentities[i].Player.SummonerName,
                        ProfileIconUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.ddVersion}/img/profileicon/{participantIdentities[i].Player.ProfileIcon}.png",
                    });
                }
            }

            return players;
        }

        public async Task<List<PlayerDTO>> GetPlayersByParticipantsDto(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
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
                        Champion = await this.championsService.GetChampionDto(participants[i].ChampionId),
                        KDA = $"{participants[i].Stats.Kills}/{participants[i].Stats.Deaths}/{participants[i].Stats.Assists}",
                        Damage = participants[i].Stats.TotalDamageDealtToChampions,
                        CS = $"{participants[i].Stats.NeutralMinionsKilled + participants[i].Stats.TotalMinionsKilled}",
                    });
                }
            }

            return players;
        }
    }
}
