using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = HOME; Initial Catalog = testing; Persist Security Info=True;User ID = user; Password=Rfgecnf!;TrustServerCertificate=True;");
        }
    }
}
