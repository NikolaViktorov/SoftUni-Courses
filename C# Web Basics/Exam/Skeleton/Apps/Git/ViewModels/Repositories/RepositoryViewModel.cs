using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int CommitsCount { get; set; }
    }
}
