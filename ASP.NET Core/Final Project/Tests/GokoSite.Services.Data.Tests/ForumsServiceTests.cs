namespace GokoSite.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GokoSite.Data;
    using GokoSite.Data.Models;
    using Microsoft.EntityFrameworkCore;

    using Xunit;

    public class ForumsServiceTests
    {
        [Fact]
        public async Task Test()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("forumTest");
            var db = new ApplicationDbContext(options.Options);
        }
    }
}
