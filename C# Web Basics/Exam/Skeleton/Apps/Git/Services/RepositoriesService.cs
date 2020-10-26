using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string type, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = type == "Private" ? false : true,
                OwnerId = userId
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public ICollection<RepositoryViewModel> GetPrivate(string userId)
        {
            var repos = this.db.Repositories
                .Where(r => r.OwnerId == userId && r.IsPublic == false)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    CreatedOn = r.CreatedOn,
                    Name = r.Name,
                    CommitsCount = r.Commits.Count,
                    OwnerName = r.Owner.Username
                }).ToList();

            return repos;
        }

        public ICollection<RepositoryViewModel> GetPublic()
        {
            var repos = this.db.Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryViewModel
            {
                Id = r.Id,
                CreatedOn = r.CreatedOn,
                Name = r.Name,
                CommitsCount = r.Commits.Count,
                OwnerName = r.Owner.Username
            }).ToList();

            return repos;
        }

    }
}
