using FilmHarbor.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FilmHarbor.Infrastructure.DatabaseContext
{
    public class FilmHarborDbContext : IdentityDbContext<User, Role, int>
    {
        public FilmHarborDbContext(DbContextOptions options) : base(options)
        {
        }
        public FilmHarborDbContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        //public DbSet<Core.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FavouriteMovies)
                .WithMany(e => e.FavouriteByUsers)
                .UsingEntity("FavouriteMovies");

            modelBuilder.Entity<User>()
                .HasMany(e => e.FavouriteMovies)
                .WithMany(e => e.FavouriteByUsers)
                .UsingEntity(
                    j =>
                    {
                        j.Property("FavouriteByUsersId").HasColumnName("UserId");
                        j.Property("FavouriteMoviesId").HasColumnName("MovieId");
                    });

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
