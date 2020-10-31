using RiotSharp.Endpoints.MatchEndpoint;
using Suls.ViewModels.Games.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IPlayersService
    {
        ICollection<Data.LoL.Player> GetPlayersByParticipants(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId);

        List<PlayerDTO> GetPlayersByParticipantsDto(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId);
    }
}
