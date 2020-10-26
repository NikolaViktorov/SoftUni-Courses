using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateCommit(string repoId, string description, string userId)
        {
            var commit = new Commit
            {
                RepositoryId = repoId,
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void DeleteCommit(string id)
        {
            var commit = this.db.Commits.FirstOrDefault(c => c.Id == id);

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new CommitViewModel
                {
                    Id = c.Id,
                    RepositoryName = c.Repository.Name,
                    CreatedOn = c.CreatedOn,
                    Description = c.Description
                }).ToList();

            return commits;
        }

        public CreateCommitViewModel GetCreateCommitViewModel(string id)
        {
            return this.db.Repositories.Where(r => r.Id == id)
                .Select(r => new CreateCommitViewModel
                {
                    Name = r.Name,
                    Id = r.Id
                }).FirstOrDefault();
        }
    }
}
