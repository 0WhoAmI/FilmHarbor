using FilmHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.DatabaseContext
{
    public class FilmHarborDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
