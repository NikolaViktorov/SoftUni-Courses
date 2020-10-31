using System;
using System.Collections.Generic;
using System.Text;
using RiotSharp.Endpoints.MatchEndpoint;
using Suls.Data.LoL;
using Suls.Services.StaticData;
using Suls.ViewModels.Games.DTOs;

namespace Suls.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly string ddVersion;
        private readonly IChampionsService championsService;

        public PlayersService(IChampionsService championsService)
        {
            this.ddVersion = PublicData.ddVerision;
            this.championsService = championsService;
        }

        public ICollection<Data.LoL.Player> GetPlayersByParticipants(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
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

        public List<PlayerDTO> GetPlayersByParticipantsDto(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId)
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
