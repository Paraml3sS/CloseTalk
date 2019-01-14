using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CloseTalk.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=DESKTOP-22TA5GA\YBSQL;Database=CloseTalkDb;Integrated Security=True;App=EntityFramework";

            return new AppDbContext(
                    new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlServer(connectionString)
                        .Options
                );
        }
    }
}
