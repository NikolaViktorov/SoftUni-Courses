using Suls.Data.LoL;
using Suls.ViewModels.Games.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Suls.Services
{
    public interface IChampionsService
    {
        Task<Champion> GetChampion(int championId);

        Task<ChampionDTO> GetChampionDto(int championId);

    }
}
