namespace GokoSite.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using GokoSite.Services.Data.StaticData;
    using RiotSharp;

    public class SpellsService : ISpellsService
    {
        public RiotApi Api { get; set; }

        public SpellsService()
        {
            this.Api = RiotApi.GetDevelopmentInstance(PublicData.apiKey);
        }

        public async Task<string> GetSpellUrlById(int id)
        {
            var spells = await this.Api.StaticData.SummonerSpells.GetAllAsync(PublicData.ddVerision);
            var fullName = spells.SummonerSpells.FirstOrDefault(s => s.Value.Id == id).Value.Image.Full;

            return $"http://ddragon.leagueoflegends.com/cdn/{PublicData.ddVerision}/img/spell/{fullName}";
        }
    }
}
