namespace GokoSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GokoSite.Data;
    using GokoSite.Data.Models.News;
    using GokoSite.Web.ViewModels.News;

    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext db;

        public NewsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddNew(NewAddInputModel input, string userId)
        {
            var newDb = new New()
            {
                Title = input.Title,
                Content = input.Content,
                Image = input.Image,
                UserId = userId,
            };

            this.db.News.Add(newDb);

            await this.db.SaveChangesAsync();
        }

        public void EditNew(NewAddInputModel input)
        {
            throw new NotImplementedException();
        }

        public ICollection<NewHomePageViewModel> GetNews()
        {
            var news = this.db.News.Select(n => new NewHomePageViewModel()
            {
                NewId = n.NewId,
                Title = n.Title,
                Image = n.Image,
            }).ToList();

            return news;
        }

        public void RemoveNew(string newId)
        {
            throw new NotImplementedException();
        }

        public NewDetailsPageViewModel GetNew(string newId, string authorUsername)
        {
            var newDb = this.db.News.FirstOrDefault(n => n.NewId == newId);

            var newModel = new NewDetailsPageViewModel()
            {
                NewId = newId,
                Title = newDb.Title,
                Content = newDb.Content,
                Image = newDb.Image,
                AuthorUsername = authorUsername,
            };

            return newModel;
        }
    }
}
