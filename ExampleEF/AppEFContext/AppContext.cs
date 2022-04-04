using ExampleEF.EF;
using Microsoft.EntityFrameworkCore;

namespace ExampleEF.AppEFContext
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = HOME; Initial Catalog = library; Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
