using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.Repositories
{
    public class FavouriteMoviesRepository : IFavouriteMoviesRepository
    {
        private readonly FilmHarborDbContext _dbContext;

        public FavouriteMoviesRepository(FilmHarborDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Movie>> GetFavouriteMovies(int userId)
        {
            int[] movieIds = _dbContext.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavouriteMovies.Select(fm => fm.Id))
                .ToArray();

            List<Movie> movies = await _dbContext.Movies
                .Where(movie => movieIds.Contains(movie.Id))
                .ToListAsync();

            return movies;
        }

        public async Task<bool> AddFavouriteMovie(int userId, int movieId)
        {
            User? user = await _dbContext.Users.Include(u => u.FavouriteMovies).FirstOrDefaultAsync(u => u.Id == userId);
            Movie? movie = await _dbContext.Movies.FindAsync(movieId);

            if (user != null && movie != null)
            {
                if (!user.FavouriteMovies.Any(fm => fm.Id == movieId))
                {
                    user.FavouriteMovies.Add(movie);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> RemoveFavouriteMovie(int userId, int movieId)
        {
            User? user = await _dbContext.Users.Include(u => u.FavouriteMovies).FirstOrDefaultAsync(u => u.Id == userId);
            Movie? movie = await _dbContext.Movies.FindAsync(movieId);

            if (user != null && movie != null)
            {
                Movie? movieToRemove = user.FavouriteMovies.FirstOrDefault(fm => fm.Id == movieId);
                if (movieToRemove != null)
                {
                    user.FavouriteMovies.Remove(movieToRemove);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
