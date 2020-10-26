using Microsoft.EntityFrameworkCore;
using Suls.Data.LoL;

namespace Suls.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions db)
            : base(db)
        {
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Champion> ChampionsStatic { get; set; }

        public DbSet<PlayerChampion> PlayerChampion { get; set; }

        public DbSet<UserGames> UserGames { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=lolapp;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerChampion>().HasKey(x => new { x.PlayerId, x.ChampionId });
            modelBuilder.Entity<UserGames>().HasKey(x => new { x.UserId, x.GameId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
