namespace GokoSite.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GokoSite.Web.ViewModels.News;

    public interface INewsService
    {
        public ICollection<NewHomePageViewModel> GetNews();

        public NewDetailsPageViewModel GetNew(string newId, string authorUsername);

        public Task AddNew(NewAddInputModel input, string userId);

        public void RemoveNew(string newId);

        public void EditNew(NewAddInputModel input);
    }
}
