using FilmHarbor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FilmHarbor.Infrastructure.DatabaseContext
{
    public class FilmHarborDbContext : DbContext
    {
        public FilmHarborDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Category>().ToTable("Categories");

            //Seed to Categories
            string categoriesJson = File.ReadAllText("../FilmHarbor.Infrastructure/Data/categories.json");
            List<Category> categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);

            foreach (Category category in categories)
            {
                modelBuilder.Entity<Category>().HasData(category);
            }

            //Seed to Movies
            string moviesJson = File.ReadAllText("../FilmHarbor.Infrastructure/Data/movies.json");
            List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);

            foreach (Movie movie in movies)
            {
                modelBuilder.Entity<Movie>().HasData(movie);
            }
        }
    }
}
