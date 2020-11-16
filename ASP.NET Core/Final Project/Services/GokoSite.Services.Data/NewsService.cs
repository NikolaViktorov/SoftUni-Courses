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
                UploadedOn = DateTime.UtcNow,
            };

            this.db.News.Add(newDb);

            await this.db.SaveChangesAsync();
        }

        public async Task EditNew(NewAddInputModel input, string newId)
        {
            var newDb = this.db.News.FirstOrDefault(n => n.NewId == newId);

            if (newDb != null)
            {
                newDb.Title = input.Title;
                newDb.Content = input.Content;
                newDb.Image = input.Image;

                await this.db.SaveChangesAsync();
            }
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

        public async Task<bool> RemoveNew(string newId)
        {
            var newDb = this.db.News.FirstOrDefault(n => n.NewId == newId);

            if (newDb != null)
            {
                this.db.News.Remove(newDb);
                await this.db.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public NewDetailsPageViewModel GetNew(string newId)
        {
            var newDb = this.db.News.FirstOrDefault(n => n.NewId == newId);

            var user = this.db.Users.FirstOrDefault(u => u.Id == newDb.UserId);

            var newModel = new NewDetailsPageViewModel()
            {
                NewId = newId,
                Title = newDb.Title,
                Content = newDb.Content,
                Image = newDb.Image,
                AuthorUsername = user?.UserName,
                UploadedOn = newDb.UploadedOn,
            };

            return newModel;
        }
    }
}
