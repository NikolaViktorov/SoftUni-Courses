using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;
using Suls.Data;
using Suls.Data.LoL;
using Suls.Services.StaticData;
using Suls.ViewModels.Games.DTOs;

namespace Suls.Services
{
    public class ChampionsService : IChampionsService
    {
        private string ddVersion { get; set; }

        public RiotApi api { get; set; }


        private readonly ApplicationDbContext db;

        public ChampionsService(ApplicationDbContext db)
        {
            this.db = db;
            this.api = RiotApi.GetDevelopmentInstance(PublicData.apiKey);
            this.ddVersion = PublicData.ddVerision;
        }

        public async Task<Champion> GetChampion(int championId)
        {
            if (this.db.ChampionsStatic.ToList().Count == 0)
            {
                await UploadChamionsToDBAsync();
            }

            var champion = this.db.ChampionsStatic.FirstOrDefault(c => c.ChampionId == championId);

            return champion;
        }

        public async Task<ChampionDTO> GetChampionDto(int championId)
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
            var dic = await api.StaticData.Champions.GetAllAsync(ddVersion);
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
    }
}
