using Microsoft.EntityFrameworkCore;

namespace SnakeWPF.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RoundHistory> RoundHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Database=snake;Username=postgres;Password=admin");
    }
}
