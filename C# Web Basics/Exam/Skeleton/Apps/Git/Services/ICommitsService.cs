using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        public void CreateCommit(string repoId, string description, string userId);

        public IEnumerable<CommitViewModel> GetAll(string userId);

        public CreateCommitViewModel GetCreateCommitViewModel(string id);

        public void DeleteCommit(string id);

    }
}
