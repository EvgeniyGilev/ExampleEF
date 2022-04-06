using ExampleEF.EF;
using Microsoft.EntityFrameworkCore;

namespace ExampleEF.AppEFContext
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        //Объекты таблицы Authors
        public DbSet<Author> Authors { get; set; }

        //Объекты таблицы Themes
        public DbSet<Theme> Themes{ get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = HOME; Initial Catalog = libraryDB; Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
