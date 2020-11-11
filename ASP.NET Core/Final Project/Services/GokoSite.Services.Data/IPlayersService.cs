namespace GokoSite.Services.Data
{
    using System.Collections.Generic;

    using GokoSite.Web.ViewModels.Games.DTOs;
    using RiotSharp.Endpoints.MatchEndpoint;

    public interface IPlayersService
    {
        ICollection<GokoSite.Data.Models.LoL.Player> GetPlayersByParticipants(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId);

        List<PlayerDTO> GetPlayersByParticipantsDto(List<ParticipantIdentity> participantIdentities, List<Participant> participants, int teamId);
    }
}
