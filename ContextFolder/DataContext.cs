using Microsoft.EntityFrameworkCore;
using TestWebSite.Models;

namespace TestWebSite.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                DataBase=_EntityCoreTestWebSite;
                Trusted_Connection=True");
        }
    }
}
