using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        public ICollection<RepositoryViewModel> GetPublic();

        public ICollection<RepositoryViewModel> GetPrivate(string userId);

        public void Create(string name, string type, string userId);
    }
}
