using CloseTalk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloseTalk.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
